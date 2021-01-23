    public class ListView2 : ListView {
    
    	private List<Item2> list = new List<Item2>();
    
    	public class Item2 : ListViewItem {
    		public bool Visible = true;
    		public Object Value = null;
    
    		public override string ToString() {
    			return (Value == null ? String.Empty : Value.ToString());
    		}
    	}
    
    	public Item2 this[int i] {
    		get {
    			return list[i];
    		}
    	}
    
    	public int Count {
    		get {
    			return list.Count;
    		}
    	}
    
    	public void Add(Object o) {
    		Item2 item = new Item2 { Value = o, Text = (o == null ? string.Empty : o.ToString()) };
    		Items.Add(item);
    		list.Add(item);
    	}
    
    	public void RefreshVisibleItems() {
    		var top = (Item2) this.TopItem;
    		Items.Clear();
    		int k = 0;
    		foreach (var o in list) {
    			if (o == top)
    				break;
    			if (o.Visible)
    				k++;
    		}
    		Items.AddRange(list.FindAll(i => i.Visible).ToArray());
    		if (k < Items.Count)
    			this.TopItem = Items[k];
    	}
    }
    
    
    	var lv = new ListView2();
    	lv.View = View.Details;
    	lv.Columns.Add("Column1", 100, HorizontalAlignment.Center);
    
    	Button btn = new Button { Text = "Hide" , Dock = DockStyle.Bottom };
    	lv.Dock = DockStyle.Fill;
    	for (char c = 'A'; c <= 'Z'; c++)
    		lv.Add(c);
    
    	var f1 = new Form1();
    	f1.Controls.Add(lv);
    	f1.Controls.Add(btn);
    
    	btn.Click += delegate {
    		if (lv.Items.Count == 0) {
    			for (int i = 0; i < lv.Count; i++)
    				lv[i].Visible = true;
    		}
    		else {
    			lv[lv.Items.Count - 1].Visible = false;
    		}
    		lv.RefreshVisibleItems();
    	};
    
    
    	Application.Run(f1);
