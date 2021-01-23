    public class ComputerSetting
    {
        public string ComputerType;
    }
    public class ComputerList
    {
        [XmlElement("ComputerSettings")]
        public List<ComputerSettings> Computers;
    }
    var computers = (ComputerList)new XmlSerializer(typeof(ComputerList)).Deserialize(stream);
    cboKioskType.ItemsSource = computers.ComputerSettings;
    <ComboBox x:Name="cboKioskType" IsReadOnly="False" HorizontalAlignment="Left" IsEditable="True" DisplayMemberPath="ComputerType">
