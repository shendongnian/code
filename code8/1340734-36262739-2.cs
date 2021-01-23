    enum JobCategory { Accountant = 1, Engineer, Manager }
    class JobCategoryConverter : EnumConverter
    {
    	public JobCategoryConverter() : base(typeof(JobCategory)) { }
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
    	IDictionary dict = new Hashtable();
    	dict["Name"] = "Ray";
    	dict["Category"] = 1;
    
    	DictionaryPropertyGridAdapter dpg = new DictionaryPropertyGridAdapter(dict);
    	dpg.PropertyAttributes = new Dictionary<string, Attribute[]>
    	{
    		{ "Category", new Attribute[] { new TypeConverterAttribute(typeof(JobCategoryConverter)) } }
    	};
    	propertyGrid1.SelectedObject = dpg;
    }
