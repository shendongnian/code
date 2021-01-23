    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Reflection.Emit;
    using System.Text;
    using Xamarin.Forms;
    
    namespace ----
    {
        public class SelectMultipleBasePage<T> : ContentPage
        {
            public delegate void ImageSelectedHandler(object sender, EventArgs e);
            public event ImageSelectedHandler OnImageSelected;
    
            public class WrappedSelection<T> : INotifyPropertyChanged
            {
                public T Item { get; set; }
                bool isSelected = false;
                public bool IsSelected
                {
                    get
                    {
                        return isSelected;
                    }
                    set
                    {
                        if (isSelected != value)
                        {
                            isSelected = value;
                            PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
                            //						PropertyChanged (this, new PropertyChangedEventArgs (nameof (IsSelected))); // C# 6
                        }
                    }
                }
                public event PropertyChangedEventHandler PropertyChanged = delegate { };
            }
            public class TickConverter : IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    if (value is bool)
                    {
                        if ((bool)value)
                        {
                            return Device.OnPlatform("Images/checked_checkbox.png", "checked_checkbox.png", "Images/checked_checkbox.png");
                            
                        }
                        else
                        {
                            return Device.OnPlatform("Images/unchecked_checkbox.png", "unchecked_checkbox.png", "Images/unchecked_checkbox.png");
                           
                        }
                    }
                    else
                    {
                        return Device.OnPlatform("Images/unchecked_checkbox.png", "unchecked_checkbox.png", "Images/unchecked_checkbox.png");
                       
                    }
                }
    
                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
    
            }
    
            public class WrappedItemSelectionTemplate : ViewCell
            {
                private readonly ImageSelectedHandler _parentHandler;
            
                static int i = 0; 
                public WrappedItemSelectionTemplate(ImageSelectedHandler parentHandler)
                    : base()
                {
    
                    _parentHandler = parentHandler;
                    List<ListItems> items = new List<ListItems>();
                    if (Application.Current.Properties.ContainsKey("SelectedPage"))
                    {
                        if (Application.Current.Properties["SelectedPage"].ToString() == "recording")
                        {
                            items = RecordingListPage.items;
                        }
                        else
                        {
                            items = RecordingDetailsPage.items;
                        }
                    }
    
                    Grid objGrid = new Grid();
                    //
                    objGrid.RowDefinitions.Add(new RowDefinition
                    {
                        Height = new GridLength(1, GridUnitType.Star)
                    });
                    objGrid.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(75, GridUnitType.Absolute),
                    });
                    objGrid.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(1, GridUnitType.Star)
                    });
                    objGrid.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(75, GridUnitType.Absolute),
                    });
    
                    // Column 1:-
                    Image objImage = new Image();
                    objImage.SetBinding(Image.SourceProperty, new Binding("Item.Image"));
                    objGrid.Children.Add(objImage, 0, 0);
                    StackLayout objStackLayoutCol2 = new StackLayout();
                    objGrid.Children.Add(objStackLayoutCol2, 1, 0);
    
                    Label name = new Label()
                    {
                        Text = "Name",
                        Style = (Style)Application.Current.Resources["LabelStyle"],
                    };
                    Label date = new Label()
                    {
                        Text = "Date",
                        Style = (Style)Application.Current.Resources["LabelStyleTiny"]
                    };
                    name.SetBinding(Label.TextProperty, new Binding("Item.Name"));
                    date.SetBinding(Label.TextProperty, new Binding("Item.Date"));
                    objStackLayoutCol2.Children.Add(name);
                    objStackLayoutCol2.Children.Add(date);
                    objStackLayoutCol2.Padding = new Thickness(10);
    
                    Image objImageView = new Image();
                    objImageView.Source = Device.OnPlatform("Icons/ic_mode_edit.png", "Search.png", "Images/Search.png");//ImageSource.FromFile("Search.png");
    
                    StackLayout stv = new StackLayout();
                    stv.Children.Add(objImageView);
                    stv.Padding = new Thickness(10);
                    stv.HorizontalOptions = LayoutOptions.Center;
                    stv.VerticalOptions = LayoutOptions.Center;
    
                    objImageView.SetBinding(Image.SourceProperty, "IsSelected", converter: new TickConverter());
    
    
                    objImage.StyleId = items[i].Id.ToString();
                    i++;
                    if (i == items.Count)
                    {
                        i = 0;
                    }
    
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += OnImageBtnTapped;
                    objImage.GestureRecognizers.Add(tapGestureRecognizer);
                   
                    objGrid.Children.Add(stv, 2, 0);
                    var moreAction = new MenuItem { Text = "More" };
    
                    moreAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
                    moreAction.Clicked += (sender, e) =>
                    {
                        var mi = ((MenuItem)sender);
                    };
    
                    var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
                    deleteAction.Icon = Device.OnPlatform("Icons/cancel.png", "cancel.png", "Images/cancel.png");
                    deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
                    deleteAction.Clicked += (sender, e) =>
                    {
                        var mi = ((MenuItem)sender);
                    };
    
                    //
                    // add context actions to the cell
                    //
                    ContextActions.Add(moreAction);
                    ContextActions.Add(deleteAction);
    
                    StackLayout st = new StackLayout();
                    st.Children.Add(objGrid);
                    st.Children.Add(new BoxView() { Color = Color.FromHex("#A4B3C1"), WidthRequest = 100, HeightRequest = 1 });
    
    
                    View = st;
    
    
                }
                private void OnImageBtnTapped(object sender, EventArgs e)
                {
                    //...
                    _parentHandler.Invoke(sender, e);
                }
            }
            public static List<WrappedSelection<T>> WrappedItems = new List<WrappedSelection<T>>();
            public SelectMultipleBasePage(List<T> items)
            {
                WrappedItems = items.Select(item => new WrappedSelection<T>() { Item = item, IsSelected = false }).ToList();
                ListView mainList = new ListView()
                {
                    ItemsSource = WrappedItems,
                    ItemTemplate = new DataTemplate(() => new WrappedItemSelectionTemplate(HandleImageSelected)),
           
                };
    
                mainList.ItemSelected += (sender, e) =>
                {
                    if (e.SelectedItem == null) return;
                    var o = (WrappedSelection<T>)e.SelectedItem;
                    o.IsSelected = !o.IsSelected;
                    ((ListView)sender).SelectedItem = null; //de-select
                };
                Content = mainList;
                mainList.HasUnevenRows = true;
    
    
                if (Device.OS == TargetPlatform.WinPhone)
                {   
                    mainList.RowHeight = 40;
                    ToolbarItems.Add(new ToolbarItem("All", "check.png", SelectAll, ToolbarItemOrder.Primary));
                    ToolbarItems.Add(new ToolbarItem("None", "cancel.png", SelectNone, ToolbarItemOrder.Primary));
                }
                else
                {
                    ToolbarItems.Add(new ToolbarItem("All", null, SelectAll, ToolbarItemOrder.Primary));
                    ToolbarItems.Add(new ToolbarItem("None", null, SelectNone, ToolbarItemOrder.Primary));
                }
            }
    
            private void HandleImageSelected(object sender, EventArgs e)
            {
                if (OnImageSelected != null)
                {
                    OnImageSelected(sender, e);
                }
            }
            void SelectAll()
            {
                foreach (var wi in WrappedItems)
                {
                    wi.IsSelected = true;
                }
            }
            void SelectNone()
            {
                foreach (var wi in WrappedItems)
                {
                    wi.IsSelected = false;
                }
            }
            public static List<T> GetSelection()
            {
                return WrappedItems.Where(item => item.IsSelected).Select(wrappedItem => wrappedItem.Item).ToList();
            }
        }
    }
