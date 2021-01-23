         public class xTreeViewItem : INotifyPropertyChanged
         {
              public int id { get; set; }
              public string Header { get; set; }
              public int parent;
              public List<xTreeViewItem > children { get; set; }
              public bool isGroup = false;
              public bool ParentResolved = false;
              public float order {get;set;}
              
              public void NotifyPropertyChanged(string info)
              {
                   if (PropertyChanged != null)
                   {
                         PropertyChanged(this, new PropertyChangedEventArgs(info));
                   }
              }
              public event PropertyChangedEventHandler PropertyChanged;
         }
