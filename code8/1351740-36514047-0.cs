    public class RowObj
        {
            public int Index { get; set; }
            public string Data { get; set; }
        }
   
     void Populate()
        {
            List<RowObj> model = new List<RowObj>();
            model.Add(new RowObj {  Index=1, Data="Apple"});
            model.Add(new RowObj { Index = 2, Data = "Cherry" });
            DG.ItemsSource = model;
            DG.Items.Refresh();
        }
