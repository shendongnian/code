    // event handler
    protected void ScanDetected(sender object, args e)
    {
        Fingerprint fp = //data received
        RespondToScan(fp);
    }
    
    internal void RespondToScan(Fingerprint _fp)
    {
       Person who = GetPersonWithFingerprint(_fp);
       PersonForm pf = new PersonForm(who);
       pf.ShowDialog();
    }
    internal Person GetPersonWithFingerprint(Fingerprint _fp)
    {
        Person person = null;
        if (lotsOfSquigglyLinesAndSuch)
        {
           person = new Person();
           person.FirstName = "John";
           person.LastName = "Dillinger";
           . . .
        }
        else if (someOtherCharacteristic)
        {
           . . .
        }
        return person;
    }
    
    // Form that will be invoked and display user's data:
    class PersonForm: Form
    . . .
    string _firstname;
    string _lastname;
    public PersonForm(Person person)
    {
        _firstname = person.FirstName;
        . . .             
    }
    private void FormShow(sender object, eventargs e)
    {
        textboxFirstName.Text = _firstName;
        . . .  
    }
    
    // class to hold data
    public class Person
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        Picture Mugshot { get; set; }
        . . .
    }
