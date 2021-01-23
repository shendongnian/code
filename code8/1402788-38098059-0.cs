    public class Person {
        public byte[] Photo { get; set; }
    }
    //...
    gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
    gridView1.EditFormPrepared += gridView1_EditFormPrepared;
    gridControl1.DataSource = new List<Person> { 
        new Person()
    };
    //...
    void gridView1_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e) {
        var binding = e.BindableControls["Photo"].DataBindings["EditValue"];
        binding.Parse += binding_ParseImageIntoByteArray;
    }
    void binding_ParseImageIntoByteArray(object sender, ConvertEventArgs e) {
        Image img = e.Value as Image;
        if(img != null && e.DesiredType == typeof(byte[])) {
            using(var ms = new System.IO.MemoryStream()) {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                // get bytes
                e.Value = ms.GetBuffer();
            }
        }
    }
