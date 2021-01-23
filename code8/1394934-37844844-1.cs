    //  ViewModelBase defined below
    //  This class duplicates Person, but with property-change notifications for the UI. 
    //  You may see fit to add the changed notifications to Person itself and not bother 
    //  defining a separate viewmodel. 
    //  Note also that we can display this ViewModel in many different views, using 
    //  many different DataTemplates or UserControls. 
    //  If you end up using it in a lot of places, you might write a Person.ShowDialog() 
    //  overload that takes a PersonViewModel and edits it, or returns an edited copy. 
    public class PersonViewModel : ViewModelBase
    {
        public PersonViewModel(Person person = null)
        {
            if (person != null) 
            {
                //  Assuming Person has FirstName and LastName properties
                FirstName = person.FirstName;
                LastName = person.LastName;
                //  etc. etc. for all the rest
            }
        }
        public Person ToPerson()
        {
            return new Person()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                //  etc. etc. for all other properties
            };
        }
        //  Any property that will be shown in the dialog should be defined just like this.
        //  This involves a lot of copy and pasting. I wrote a snippet. Here's another:
        //  http://aaron-hoffman.blogspot.com/2010/09/visual-studio-code-snippet-for-notify.html
        private string _firstName = null;
        public string FirstName {
            get { return _firstName; }
            set {
                if (value != _firstName) {
                    _firstName = value;
                    //  If not in C#6, pass "FirstName" instead.
                    //  nameof(FirstName) keeps the parameter correct if you right-click 
                    //  Rename the property -- that can bite you. 
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
    }
