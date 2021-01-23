    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Data;
    using System.Windows.Markup;
    
    namespace WpfApplication
    {
        static class MultiSelectorExtension
        {
            public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.RegisterAttached("SelectedItems", typeof(IList), typeof(MultiSelectorExtension), new PropertyMetadata(new PropertyChangedCallback(OnSelectedItemsChanged)));
    
            private static readonly DependencyProperty SelectedItemsBinderProperty = DependencyProperty.RegisterAttached("SelectedItemsBinder", typeof(SelectedItemsBinder), typeof(MultiSelectorExtension));
    
            [AttachedPropertyBrowsableForType(typeof(MultiSelector))]
            [DependsOn("ItemsSource")]
            public static IList GetSelectedItems(this MultiSelector multiSelector)
            {
                if (multiSelector == null)
                    throw new ArgumentNullException("multiSelector");
    
                return (IList)multiSelector.GetValue(SelectedItemsProperty);
            }
    
            public static void SetSelectedItems(this MultiSelector multiSelector, IList selectedItems)
            {
                if (multiSelector == null)
                    throw new ArgumentNullException("multiSelector");
    
                multiSelector.SetValue(SelectedItemsProperty, selectedItems);
            }
    
            private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var multiSelector = d as MultiSelector;
    
                if (multiSelector == null)
                    return;
    
                var binder = (SelectedItemsBinder)multiSelector.GetValue(SelectedItemsBinderProperty);
    
                var selectedItems = e.NewValue as IList;
    
                if (selectedItems != null)
                {
                    if (binder == null)
                        binder = new SelectedItemsBinder(multiSelector);
    
                    binder.SelectedItems = selectedItems;
                }
                else if (binder != null)
                    binder.Dispose();
            }
    
            private sealed class SelectedItemsBinder : IDisposable
            {
                private static readonly IList emptyList = new object[0];
    
                private static readonly Action<MultiSelector> multiSelectorBeginUpdateSelectedItems, multiSelectorEndUpdateSelectedItems;
    
                private readonly MultiSelector multiSelector;
                private IList selectedItems;
                private IResetter selectedItemsResetter;
    
                private bool suspendMultiSelectorUpdate, suspendSelectedItemsUpdate;
    
                static SelectedItemsBinder()
                {
                    GetMultiSelectorBeginEndUpdateSelectedItems(out multiSelectorBeginUpdateSelectedItems, out multiSelectorEndUpdateSelectedItems);
                }
    
                public SelectedItemsBinder(MultiSelector multiSelector)
                {
                    this.multiSelector = multiSelector;
                    this.multiSelector.SelectionChanged += this.OnMultiSelectorSelectionChanged;
                    this.multiSelector.Unloaded += this.OnMultiSelectorUnloaded;
                    this.multiSelector.SetValue(SelectedItemsBinderProperty, this);
                }
    
                public IList SelectedItems
                {
                    get { return this.selectedItems; }
                    set
                    {
                        this.SetSelectedItemsChangedHandler(false);
                        this.selectedItems = value;
                        this.selectedItemsResetter = GetResetter(this.selectedItems.GetType());
                        this.SetSelectedItemsChangedHandler(true);
    
                        if (this.multiSelector.IsLoaded)
                            this.OnSelectedItemsCollectionChanged(this.selectedItems, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        else
                        {
                            RoutedEventHandler multiSelectorLoadedHandler = null;
                            this.multiSelector.Loaded += multiSelectorLoadedHandler = new RoutedEventHandler((sender, e) =>
                            {
                                this.OnSelectedItemsCollectionChanged(this.selectedItems, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                                this.multiSelector.Loaded -= multiSelectorLoadedHandler;
                            });
                        }
                    }
                }
    
                private int ItemsSourceCount
                {
                    get
                    {
                        var collection = this.multiSelector.ItemsSource as ICollection;
                        return collection != null ? collection.Count : -1;
                    }
                }
    
                public void Dispose()
                {
                    this.multiSelector.ClearValue(SelectedItemsBinderProperty);
                    this.multiSelector.Unloaded -= this.OnMultiSelectorUnloaded;
                    this.multiSelector.SelectionChanged -= this.OnMultiSelectorSelectionChanged;
                    this.SetSelectedItemsChangedHandler(false);
                }
    
                private void OnSelectedItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (this.suspendMultiSelectorUpdate || e.Action == NotifyCollectionChangedAction.Move)
                        return;
    
                    this.suspendSelectedItemsUpdate = true;
    
                    if (this.selectedItems.Count == 0)
                        this.multiSelector.UnselectAll();
                    else if (this.selectedItems.Count == this.ItemsSourceCount)
                        this.multiSelector.SelectAll();
                    else if (e.Action != NotifyCollectionChangedAction.Reset && (e.NewItems == null || e.NewItems.Count <= 1) && (e.OldItems == null || e.OldItems.Count <= 1))
                        UpdateList(this.multiSelector.SelectedItems, e.NewItems ?? emptyList, e.OldItems ?? emptyList);
                    else
                    {
                        if (multiSelectorBeginUpdateSelectedItems != null)
                        {
                            multiSelectorBeginUpdateSelectedItems(this.multiSelector);
                            this.multiSelector.SelectedItems.Clear();
                            UpdateList(this.multiSelector.SelectedItems, this.selectedItems, emptyList);
                            multiSelectorEndUpdateSelectedItems(this.multiSelector);
                        }
                        else
                        {
                            this.multiSelector.UnselectAll();
                            UpdateList(this.multiSelector.SelectedItems, this.selectedItems, emptyList);
                        }
                    }
    
                    this.suspendSelectedItemsUpdate = false;
                }
    
                private void OnMultiSelectorSelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                    if (this.suspendSelectedItemsUpdate)
                        return;
    
                    this.suspendMultiSelectorUpdate = true;
    
                    if (e.AddedItems.Count <= 1 && e.RemovedItems.Count <= 1)
                        UpdateList(this.selectedItems, e.AddedItems, e.RemovedItems);
                    else
                    {
                        if (this.selectedItemsResetter != null)
                            this.selectedItemsResetter.Reset(this.selectedItems, this.multiSelector.SelectedItems.Cast<object>().Where(item => item != CollectionView.NewItemPlaceholder));
                        else
                            UpdateList(this.selectedItems, e.AddedItems, e.RemovedItems);
                    }
    
                    this.suspendMultiSelectorUpdate = false;
                }
    
                private void OnMultiSelectorUnloaded(object sender, RoutedEventArgs e)
                {
                    this.Dispose();
                }
    
                private void SetSelectedItemsChangedHandler(bool add)
                {
                    var notifyCollectionChanged = this.selectedItems as INotifyCollectionChanged;
                    if (notifyCollectionChanged != null)
                    {
                        if (add)
                            notifyCollectionChanged.CollectionChanged += this.OnSelectedItemsCollectionChanged;
                        else
                            notifyCollectionChanged.CollectionChanged -= this.OnSelectedItemsCollectionChanged;
                    }
                }
    
                private static void UpdateList(IList list, IList newItems, IList oldItems)
                {
                    int addedCount = 0;
    
                    for (int i = 0; i < oldItems.Count; ++i)
                    {
                        var index = list.IndexOf(oldItems[i]);
                        if (index >= 0)
                        {
                            object newItem;
                            if (i < newItems.Count && (newItem = newItems[i]) != CollectionView.NewItemPlaceholder)
                            {
                                list[index] = newItem;
                                ++addedCount;
                            }
                            else
                                list.RemoveAt(index);
                        }
                    }
    
                    for (int i = addedCount; i < newItems.Count; ++i)
                    {
                        var newItem = newItems[i];
                        if (newItem != CollectionView.NewItemPlaceholder)
                            list.Add(newItem);
                    }
                }
    
                private static void GetMultiSelectorBeginEndUpdateSelectedItems(out Action<MultiSelector> beginUpdateSelectedItems, out Action<MultiSelector> endUpdateSelectedItems)
                {
                    try
                    {
                        beginUpdateSelectedItems = (Action<MultiSelector>)Delegate.CreateDelegate(typeof(Action<MultiSelector>), typeof(MultiSelector).GetMethod("BeginUpdateSelectedItems", BindingFlags.NonPublic | BindingFlags.Instance));
                        endUpdateSelectedItems = (Action<MultiSelector>)Delegate.CreateDelegate(typeof(Action<MultiSelector>), typeof(MultiSelector).GetMethod("EndUpdateSelectedItems", BindingFlags.NonPublic | BindingFlags.Instance));
                    }
                    catch
                    {
                        beginUpdateSelectedItems = endUpdateSelectedItems = null;
                    }
                }
    
                private static IResetter GetResetter(Type listType)
                {
                    try
                    {
                        MethodInfo genericReset = null, nonGenericReset = null;
                        Type genericResetItemType = null;
                        foreach (var method in listType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                        {
                            if (method.Name != "Reset")
                                continue;
    
                            if (method.ReturnType != typeof(void))
                                continue;
    
                            var parameters = method.GetParameters();
    
                            if (parameters.Length != 1)
                                continue;
    
                            var parameterType = parameters[0].ParameterType;
    
                            if (parameterType.IsGenericType && parameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                            {
                                genericResetItemType = parameterType.GetGenericArguments()[0];
                                genericReset = method;
                                break;
                            }
                            else if (parameterType == typeof(IEnumerable))
                                nonGenericReset = method;
                        }
    
                        if (genericReset != null)
                            return (IResetter)Activator.CreateInstance(typeof(GenericResetter<,>).MakeGenericType(genericReset.DeclaringType, genericResetItemType), genericReset);
                        else if (nonGenericReset != null)
                            return (IResetter)Activator.CreateInstance(typeof(NonGenericResetter<>).MakeGenericType(nonGenericReset.DeclaringType), nonGenericReset);
                        else
                            return null;
                    }
                    catch
                    {
                        return null;
                    }
                }
    
                private interface IResetter
                {
                    void Reset(IList list, IEnumerable items);
                }
    
                private sealed class NonGenericResetter<TTarget> : IResetter
                {
                    private readonly Action<TTarget, IEnumerable> reset;
    
                    public NonGenericResetter(MethodInfo method)
                    {
                        this.reset = (Action<TTarget, IEnumerable>)Delegate.CreateDelegate(typeof(Action<TTarget, IEnumerable>), method);
                    }
    
                    public void Reset(IList list, IEnumerable items)
                    {
                        this.reset((TTarget)list, items);
                    }
                }
    
                private sealed class GenericResetter<TTarget, T> : IResetter
                {
                    private readonly Action<TTarget, IEnumerable<T>> reset;
    
                    public GenericResetter(MethodInfo method)
                    {
                        this.reset = (Action<TTarget, IEnumerable<T>>)Delegate.CreateDelegate(typeof(Action<TTarget, IEnumerable<T>>), method);
                    }
    
                    public void Reset(IList list, IEnumerable items)
                    {
                        this.reset((TTarget)list, items.Cast<T>());
                    }
                }
            }
        }
    }
