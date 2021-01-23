    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Linq;
    using System.Security.Permissions;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace ErrorProvider
    {
        class BackgroundColorErrorProvider: Component, IExtenderProvider, ISupportInitialize
        {
    
            public BackgroundColorErrorProvider()
            {
                currentChanged = new EventHandler(ErrorManager_CurrentChanged);
            }
            public BackgroundColorErrorProvider(ContainerControl parentControl)
                : this()
            {
                this.parentControl = parentControl;
                propChangedEvent = new EventHandler(ParentControl_BindingContextChanged);
                parentControl.BindingContextChanged += propChangedEvent;
            }
            public BackgroundColorErrorProvider(IContainer container)
                : this()
            {
                if (container == null) {
                    throw new ArgumentNullException("container");
                }
     
                container.Add(this);
            }
    
            public bool CanExtend(object extendee)
            {
                return extendee is Control && !(extendee is Form) && !(extendee is ToolBar);
            }
    
            private bool inSetErrorManager = false;
            private object dataSource;
            private string dataMember = null;
            private ContainerControl parentControl;
            private BindingManagerBase errorManager;
            private bool initializing;
            private EventHandler currentChanged;
            private EventHandler propChangedEvent;
            private Dictionary<Control, Color> originalColor = new Dictionary<Control, Color>();
            private Color errorBackgroundColor;
    
            public ContainerControl ContainerControl
            {
                [UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
                [UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows)]
                get
                {
                    return parentControl;
                }
                set
                {
                    if (parentControl != value)
                    {
                        if (parentControl != null)
                            parentControl.BindingContextChanged -= propChangedEvent;
    
                        parentControl = value;
    
                        if (parentControl != null)
                            parentControl.BindingContextChanged += propChangedEvent;
    
                        Set_ErrorManager(this.DataSource, this.DataMember, true);
                    }
                }
            }
    
            public string DataMember
            {
                get { return dataMember; }
                set
                {
                    if (value == null) value = "";
                    Set_ErrorManager(this.DataSource, value, false);
                }
            }
    
            public object DataSource
            {
                get { return dataSource; }
                set 
                { 
                    if ( parentControl != null && value != null && String.IsNullOrEmpty(this.dataMember))
                    {
                        // Let's check if the datamember exists in the new data source
                        try
                        {
                            errorManager = parentControl.BindingContext[value, this.dataMember];
                        }
                        catch (ArgumentException)
                        {
                            // The data member doesn't exist in the data source, so set it to null
                            this.dataMember = "";
                        }
                    }
                    Set_ErrorManager(value, this.DataMember, false);
                }
            }
    
            public override ISite Site
            {
                set
                {
                    base.Site = value;
                    if (value == null)
                        return;
    
                    IDesignerHost host = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                    if (host != null)
                    {
                        IComponent baseComp = host.RootComponent;
    
                        if (baseComp is ContainerControl)
                        {
                            this.ContainerControl = (ContainerControl)baseComp;
                        }
                    }
                }
            }
            private ToolTip toolTip;
    
            public ToolTip ToolTip
            {
                get { return toolTip; }
                set { toolTip = value; }
            }
            
            public Color ErrorBackgroundColor
            {
                get { return errorBackgroundColor; }
                set { errorBackgroundColor = value; }
            }
            
            private void Set_ErrorManager(object newDataSource, string newDataMember, bool force)
            {
                if (inSetErrorManager)
                    return;
                inSetErrorManager = true;
                try
                {
                    bool dataSourceChanged = this.DataSource != newDataSource;
                    bool dataMemberChanged = this.DataMember != newDataMember;
    
                    //if nothing changed, then do not do any work
                    //
                    if (!dataSourceChanged && !dataMemberChanged && !force)
                    {
                        return;
                    }
    
                    // set the dataSource and the dataMember
                    //
                    this.dataSource = newDataSource;
                    this.dataMember = newDataMember;
    
                    if (!initializing)
                    {
                        UnwireEvents(errorManager);
    
                        // get the new errorManager
                        //
                        if (parentControl != null && this.dataSource != null && parentControl.BindingContext != null)
                        {
                            errorManager = parentControl.BindingContext[this.dataSource, this.dataMember];
                        }
                        else
                        {
                            errorManager = null;
                        }
    
                        // wire the events
                        //
                        WireEvents(errorManager);
    
                        // see if there are errors at the current
                        // item in the list, w/o waiting for the position to change
                        if (errorManager != null)
                            UpdateBinding();
                    }
                }
                finally
                { 
                    inSetErrorManager = false;
                }
            }
    
            public void UpdateBinding()
            {
                ErrorManager_CurrentChanged(errorManager, EventArgs.Empty);
            }
    
            private void UnwireEvents(BindingManagerBase listManager)
            {
                if (listManager != null)
                {
                    listManager.CurrentChanged -= currentChanged;
                    listManager.BindingComplete -= new BindingCompleteEventHandler(this.ErrorManager_BindingComplete);
    
                    CurrencyManager currManager = listManager as CurrencyManager;
    
                    if (currManager != null)
                    {
                        currManager.ItemChanged -= new ItemChangedEventHandler(this.ErrorManager_ItemChanged);
                        currManager.Bindings.CollectionChanged -= new CollectionChangeEventHandler(this.ErrorManager_BindingsChanged);
                    }
                }
    
            }
    
            private void WireEvents(BindingManagerBase listManager)
            {
                if (listManager != null)
                {
                    listManager.CurrentChanged += currentChanged;
                    listManager.BindingComplete += new BindingCompleteEventHandler(this.ErrorManager_BindingComplete);
    
                    CurrencyManager currManager = listManager as CurrencyManager;
    
                    if (currManager != null)
                    {
                        currManager.ItemChanged += new ItemChangedEventHandler(this.ErrorManager_ItemChanged);
                        currManager.Bindings.CollectionChanged += new CollectionChangeEventHandler(this.ErrorManager_BindingsChanged);
                    }
                }
            }
    
    
            private void ErrorManager_BindingsChanged(object sender, CollectionChangeEventArgs e)
            {
                ErrorManager_CurrentChanged(errorManager, e);
            }
    
            private void ParentControl_BindingContextChanged(object sender, EventArgs e)
            {
                Set_ErrorManager(this.DataSource, this.DataMember, true);
            }
    
            private void ErrorManager_ItemChanged(object sender, ItemChangedEventArgs e)
            {
                BindingsCollection errBindings = errorManager.Bindings;
                int bindingsCount = errBindings.Count;
    
                // If the list became empty then reset the errors
                if (e.Index == -1 && errorManager.Count == 0)
                {
                    for (int j = 0; j < bindingsCount; j++)
                    {
                        if ((errBindings[j].Control != null))
                        {
                            // ...ignore everything but bindings to Controls
                            SetError(errBindings[j].Control, "");
                        }
                    }
                }
                else
                {
                    ErrorManager_CurrentChanged(sender, e);
                }
            }
    
            private void SetError(Control control, string p)
            {
                if (String.IsNullOrEmpty(p))
                {
                    if (originalColor.ContainsKey(control))
                        control.BackColor = originalColor[control];
                    toolTip.SetToolTip(control, null);
                }
                else
                {
                    control.BackColor = ErrorBackgroundColor;
                    toolTip.SetToolTip(control, p);
                }
            }
    
            private void ErrorManager_BindingComplete(object sender, BindingCompleteEventArgs e)
            {
                Binding binding = e.Binding;
    
                if (binding != null && binding.Control != null)
                {
                    SetError(binding.Control, (e.ErrorText == null ? String.Empty : e.ErrorText));
                }
            }
    
            private void ErrorManager_CurrentChanged(object sender, EventArgs e)
            {
                if (errorManager.Count == 0)
                {
                    return;
                }
    
                object value = errorManager.Current;
                if (!(value is IDataErrorInfo))
                {
                    return;
                }
    
                BindingsCollection errBindings = errorManager.Bindings;
                int bindingsCount = errBindings.Count;
    
                // We can only show one error per control, so we will build up a string...
                //
                Hashtable controlError = new Hashtable(bindingsCount);
    
                for (int j = 0; j < bindingsCount; j++)
                {
    
                    // Ignore everything but bindings to Controls
                    if (errBindings[j].Control == null)
                    {
                        continue;
                    }
    
                    string error = ((IDataErrorInfo)value)[errBindings[j].BindingMemberInfo.BindingField];
    
                    if (error == null)
                    {
                        error = "";
                    }
    
                    string outputError = "";
    
                    if (controlError.Contains(errBindings[j].Control))
                        outputError = (string)controlError[errBindings[j].Control];
    
                    // VSWhidbey 106890: Utilize the error string without including the field name.
                    if (String.IsNullOrEmpty(outputError))
                    {
                        outputError = error;
                    }
                    else
                    {
                        outputError = string.Concat(outputError, "\r\n", error);
                    }
    
                    controlError[errBindings[j].Control] = outputError;
                }
    
                IEnumerator enumerator = controlError.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DictionaryEntry entry = (DictionaryEntry)enumerator.Current;
                    SetError((Control)entry.Key, (string)entry.Value);
                }
            }
    
    
            public void BeginInit()
            {
                initializing = true;
            }
    
            public void EndInit()
            {
                initializing = false;
                Set_ErrorManager(this.DataSource, this.DataMember, true);
            }
        }
    }
