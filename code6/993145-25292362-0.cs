    public class MyChart : Chart {
      protected override void OnBindingContextChanged(EventArgs e) {
        ((BindingList<MyObject>)this.DataSource).ListChanged -= MyChart_ListChanged;
        ((BindingList<MyObject>)this.DataSource).ListChanged += MyChart_ListChanged;
        base.OnBindingContextChanged(e);
      }
      void MyChart_ListChanged(object sender, ListChangedEventArgs e) {
        // something happened in the list...
      }
    }
