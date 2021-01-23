    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    class RegionSalePivotViewItem : CustomTypeDescriptor
    {
    	private RegionSalePivotView container;
    	private Dictionary<string, double> amountByRegion;
    	internal RegionSalePivotViewItem(RegionSalePivotView container, DateTime date, IEnumerable<RegionSale> sales)
    	{
    		this.container = container;
    		DateSale = date;
    		amountByRegion = sales.ToDictionary(sale => sale.Region, sale => sale.DollarAmount);
    	}
    	public DateTime DateSale { get; private set; }
    	public double? GetAmount(string region)
    	{
    		double value;
    		return amountByRegion.TryGetValue(region, out value) ? value : (double?)null;
    	}
    	public override PropertyDescriptorCollection GetProperties()
    	{
    		return container.GetItemProperties(null);
    	}
    }
    
    class RegionSalePivotView : ReadOnlyCollection<RegionSalePivotViewItem>, ITypedList
    {
    	private PropertyDescriptorCollection properties;
    	public RegionSalePivotView(IEnumerable<RegionSale> source) : base(new List<RegionSalePivotViewItem>())
    	{
    		// Properties
    		var propertyList = new List<PropertyDescriptor>();
    		propertyList.Add(new Property<DateTime>("DateSale", (item, p) => item.DateSale));
    		foreach (var region in source.Select(sale => sale.Region).Distinct().OrderBy(region => region))
    			propertyList.Add(new Property<double?>(region, (item, p) => item.GetAmount(p.Name)));
    		properties = new PropertyDescriptorCollection(propertyList.ToArray());
    		// Items
    		((List<RegionSalePivotViewItem>)Items).AddRange(
    			source.GroupBy(sale => sale.DateSale,
    				(date, sales) => new RegionSalePivotViewItem(this, date, sales))
    				.OrderBy(item => item.DateSale)
    		);
    	}
    	public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors) { return properties; }
    	public string GetListName(PropertyDescriptor[] listAccessors) { return null; }
    	class Property<T> : PropertyDescriptor
    	{
    		Func<RegionSalePivotViewItem, Property<T>, T> getValue;
    		public Property(string name, Func<RegionSalePivotViewItem, Property<T>, T> getValue) : base(name, null) { this.getValue = getValue; }
    		public override Type ComponentType { get { return typeof(RegionSalePivotViewItem); } }
    		public override Type PropertyType { get { return typeof(T); } }
    		public override object GetValue(object component) { return getValue((RegionSalePivotViewItem)component, this); }
    		public override bool IsReadOnly { get { return true; } }
    		public override bool CanResetValue(object component) { return false; }
    		public override void ResetValue(object component) { throw new NotSupportedException(); }
    		public override void SetValue(object component, object value) { throw new NotSupportedException(); }
    		public override bool ShouldSerializeValue(object component) { return false; }
    	}
    }
