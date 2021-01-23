    [XmlRoot("EDSRegister")]
    public class EDSRegister {
    }
    [XmlRoot("EDSRegisters")]
    public class EDSRegisters : ObservableCollection<EDSRegister> {
      public EDSRegisters() {
      }
    }
    
