	//Inside myType as a sub class
	public class myTypeElement : ConfigurationElement {
		   [ConfigurationProperty("data", IsRequired = false)]
		   public string Data {
				get { return (string)this["data"];  }
				set { this["data"]=value;}
			}
	}
