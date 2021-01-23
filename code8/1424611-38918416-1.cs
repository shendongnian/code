    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Data;
    using System.Globalization;
    using System.ComponentModel;
    
    namespace Local {
        /// <summary>Interaction logic for WDataGridTest.xaml</summary>
        public partial class WDataGridTest : Window {
            public WDataGridTest() {
                InitializeComponent();
            }
        }
    
        public class DataTable : BindingList<DataRow>, ITypedList {
            private PropertyDescriptorCollection _PropertyDescriptors;
    
            public DataTable() :
                base() {
                AllowNew = false;
                AllowRemove = false;
                AllowEdit = true;
                _PropertyDescriptors = new PropertyDescriptorCollection(new PropertyDescriptor[0], false);
                _PropertyDescriptors.Add(new DataValuePropertyDescriptor("Column1"));
                _PropertyDescriptors.Add(new DataValuePropertyDescriptor("Column1"));
                _PropertyDescriptors.Add(new DataValuePropertyDescriptor("Column1"));
                Items.Add(new DataRow(this));
                Items.Add(new DataRow(this));
                Items.Add(new DataRow(this));
                Items.Add(new DataRow(this));
                Items.Add(new DataRow(this));
            }
    
            #region ITypedList implementation
            public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] ListAccessors) {
                return _PropertyDescriptors;
            }
            public string GetListName(PropertyDescriptor[] ListAccessors) {
                return "Data Table";
            }
            #endregion ITypedList implementation
        }
    
        public class DataRow : ICustomTypeDescriptor {
            public DataRow(DataTable DataTable) {
                this.DataTable = DataTable;
            }
    
            public DataTable DataTable {
                get;
                private set;
            }
    
            public object GetValue(string ColumnName) {
                return string.Concat(ColumnName, "@", GetHashCode());
            }
    
            public void SetValue(string ColumnName, object Value) {
            }
    
            #region ICustomTypeDescriptor implementation
            public AttributeCollection GetAttributes() { return AttributeCollection.Empty; }
            public string GetClassName() { return GetType().FullName; }
            public string GetComponentName() { return GetType().Name; }
            public TypeConverter GetConverter() { return null; }
            public EventDescriptor GetDefaultEvent() { return null; }
            public PropertyDescriptor GetDefaultProperty() { return null; }
            public object GetEditor(Type EditorBaseType) { return null; }
            public EventDescriptorCollection GetEvents(Attribute[] Attributes) { return EventDescriptorCollection.Empty; }
            public EventDescriptorCollection GetEvents() { return EventDescriptorCollection.Empty; }
            public PropertyDescriptorCollection GetProperties(Attribute[] Attributes) { return DataTable.GetItemProperties(null); }
            public PropertyDescriptorCollection GetProperties() { return DataTable.GetItemProperties(null); }
            public object GetPropertyOwner(PropertyDescriptor PropertyDescriptor) { return this; }
            #endregion Property value tracking
        }
    
        public class DataValuePropertyDescriptor : PropertyDescriptor {
            public DataValuePropertyDescriptor(string Name) :
                base(Name, new Attribute[] { new DisplayNameAttribute(string.Concat("Display: ", Name)) }) {
            }
    
            #region PropertyDescriptor implementation
            public override Type ComponentType { get { return typeof(DataRow); } }
            public override Type PropertyType { get { return typeof(string); } }
            public override bool IsReadOnly { get { return false; } }
            public override bool CanResetValue(object DataRow) { return true; }
            public override object GetValue(object DataRow) { return ((DataRow)DataRow).GetValue(Name); }
            public override void ResetValue(object DataRow) { ((DataRow)DataRow).SetValue(Name, null); }
            public override void SetValue(object DataRow, object Value) { ((DataRow)DataRow).SetValue(Name, Value); }
            public override bool ShouldSerializeValue(object DataRow) { return false; }
            #endregion PropertyDescriptor implementation
        }
    
        public class DataColumnDisplayNameConverter : IValueConverter {
            public DataColumnDisplayNameConverter()
                : base() {
            }
    
            public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture) {
                DataTable table = (DataTable)Parameter;
                string property = (string)Value;
                foreach (PropertyDescriptor descriptor in table.GetItemProperties(null)) {
                    if (property == descriptor.Name) {
                        return descriptor.DisplayName;
                    }
                }
                return DependencyProperty.UnsetValue;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                throw new NotImplementedException();
            }
        }
    }
