    class Itm
    {
        string A {get; set;}
        string B {get; set;}
        string C {get; set;}
    }
    
    void Setup()
    {
        for (int i = 1; i < 4; i++)
        {
            cbo.Items.Add(new itm { a = "A" + i, b = "B" + i, c = "C" + i});
        }
        cbo.DisplayMember = "A";
        cbo.ValueMember = "B";
    }
    void OnSelectedIndexChanged(....)
    {
         if (cbo.SelectedIndex > -1)
         {
             var item = (itm)cbo.SelectedItem;
             MessageBox.Show(string.Format("Selected: {0}, {1}, {2}", item.A, item.B, item.C));
         }
    }
