    public class PersonUC : UserControl
    {
	   public Person;
	   public PersonUC(Person p)
	   {
		Person = p;
	   }
    }
    public class MainWindow
    {
    	private List<PersonUC> personUCs;
    
    	private void MethodCalledAfterEventSelected(List<Person> p)
    	{
    		//circle through the collection to add the UCs to your listbox
    		personUCs = new List<PersonUC>();
    		foreach(var item in p)
    		{
    			personUCs.Add(new PersonUC(item));
    		}
    		yourListBox.Items = personsUC;
    	}
    	
    	private List<Person> GetAttendet()
    	{
    		List<Person> attendet = new List<Person>();
    		foreach (PersonUC item in personsUC) 
    		{
    			if(item.youCheckboxName.Checked)
    				attendet.Add(item.Person);
    		}
    		return attendet;
    	}
    }
