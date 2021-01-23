    void Main() {
        string searchQuery = "foo bar";
        IEnumerable<PatientStep> patientSteps = new PatientStep[] {
            new PatientStep("foo", "bar", "12345"),
            new PatientStep("foo", "williams", "12345"),
            new PatientStep("nancy", "bar", "12345"),
            new PatientStep("nothing", "relevant", "12345"),
        };
    
        var searchWords = searchQuery
                        .Split(' ')
                        .Select(x => x.Trim()
                            .ToLower())
                        .Where(y => !string.IsNullOrWhiteSpace(y)).ToArray();
    
        foreach (var searchWord in searchWords) {
            var word = searchWord;
            patientSteps = patientSteps.Where(
                x => x.User.FirstName.ToLower().Contains(word)
                    || x.User.LastName.ToLower().Contains(word)
                    || x.User.CellPhone.Contains(word)
            );
        }
    
        foreach (var patientStep in patientSteps) {
            Console.WriteLine(patientStep.ToString());
        }
    }
    
    class PatientStep {
        public User User { get; private set; }
    
        public PatientStep(string first, string last, string cell) {
            this.User = new User { FirstName = first, LastName = last, CellPhone = cell };
        }
    
        public override string ToString() {
            return string.Format("{0} {1}, {2}", this.User.FirstName, this.User.LastName, this.User.CellPhone);
        }
    }
    
    class User {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
    }
