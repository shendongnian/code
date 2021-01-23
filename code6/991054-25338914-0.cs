    //this is the view model
    //The user sees this model
    public class Person {
        public string Name { get; set; }
        public bool IsReceiver { get; set; }
        public bool IsPayer { get; set; }
    }
    //these are the domain models
    //The database uses these models
    public class Receiver {
        [Key]
        public int ReceiverId { get; set; }
        public string Name { get; set; }
        [Required]
        public int PayerId { get; set; }
        public virtual Payer Payer { get; set; }
    }
    public class Payer {
        [Key]
        public int PayerId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Receiver> Receivers { get; set; }
    }
    public class AccountController {
        //create a view for the Person View Model
        //this is your abstraction
        public void SignUp(Person p) {
            //create models for the repository
            Payer payer = new Payer() {
                Name = p.Name
            };
            Receiver receiver = new Reciever() {
                Name = p.Name
            };
            //if the payer is his own receiver:
            Receiver.Payer = payer;
            
            //if the payer is his own receiver:
            Payer.Receivers.Add(receiver);
            //create for each depending upon some condition
            //I've just allowed the user to select whether he is a payer
            //based upon a checkbox on the form I suppose
            if (p.IsPayer) {
                db.Payers.Add(payer);
            }
            if (p.IsReceiver) {
                db.Receivers.Add(receiver);
            }
            db.SaveChanges();
        }
    }
