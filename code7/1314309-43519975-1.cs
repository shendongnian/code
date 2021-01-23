    using System.Data.Entity.Core.Objects;
    ...
    db = new myEntities1();
    ObjectParameter returnId = new ObjectParameter("returnId", DbType.Int64);
    db.postLogItem("New item.", returnId);
    MessageBox.Show("Logitem added. New returnId: " + (int)returnId.Value);
