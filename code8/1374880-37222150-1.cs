    public class MyLi: ListItem
    {
        public DriveInfo DI { get; set;}
        public override string ToString()
        {
            return DI.ToString();
        }
    }
    foreach(DriveInfo di in DriveInfo.GetDrives())
    {
        MyLi li= new MyLi();
        li.MI= di;
        lstdrive.Items.Add(li);
    }
