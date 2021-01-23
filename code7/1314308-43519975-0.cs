    using System.Data.Entity.Core.Objects;
    ...
    db = new myEntities1();
    ObjectParameter id;
    db.postLogItem("New item.", id);
    MessageBox.Show("Logitem added. New id: " + (int)id.Value);
