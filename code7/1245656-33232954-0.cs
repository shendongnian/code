   	[XmlRoot(ElementName="DateOfBirth", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    	public class DateOfBirth {
    		[XmlElement(ElementName="date", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    		public string Date { get; set; }
    	}
    
    	[XmlRoot(ElementName="Animal", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    	public class Animal {
    		[XmlElement(ElementName="ChipRegistrationNumber", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    		public string ChipRegistrationNumber { get; set; }
    		[XmlElement(ElementName="DateOfBirth", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    		public DateOfBirth DateOfBirth { get; set; }
    		[XmlElement(ElementName="IsReserved", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    		public string IsReserved { get; set; }
    		[XmlElement(ElementName="Name", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    		public string Name { get; set; }
    		[XmlElement(ElementName="BadHabits", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    		public string BadHabits { get; set; }
    		[XmlElement(ElementName="Price", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    		public string Price { get; set; }
    		[XmlAttribute(AttributeName="type", Namespace="http://www.w3.org/2001/XMLSchema-instance")]
    		public string Type { get; set; }
    		[XmlElement(ElementName="LastWalkDate", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    		public LastWalkDate LastWalkDate { get; set; }
    	}
    
    	[XmlRoot(ElementName="LastWalkDate", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    	public class LastWalkDate {
    		[XmlElement(ElementName="date", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    		public string Date { get; set; }
    	}
    
    	[XmlRoot(ElementName="ArrayOfAnimal", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    	public class ArrayOfAnimal {
    		[XmlElement(ElementName="Animal", Namespace="http://schemas.datacontract.org/2004/07/AnimalShelter")]
    		public List<Animal> Animal { get; set; }
    		[XmlAttribute(AttributeName="i", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string I { get; set; }
    		[XmlAttribute(AttributeName="xmlns")]
    		public string Xmlns { get; set; }
    	}
