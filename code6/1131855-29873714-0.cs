    using System;
    namespace BlogPartialUpdateTrick
    {
        public class SomeClass
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int? HeightInches { get; set; }
            public DateTime? Dob { get; set; }
            public void SetAll(SomeClass source)
            {
                this.FirstName = source.FirstName ?? this.FirstName;
                this.LastName = source.LastName ?? this.LastName;
                this.HeightInches = source.HeightInches ?? this.HeightInches;
                this.Dob = source.Dob ?? this.Dob;
            }
            public override string ToString()
            {
                return String.Format("fn: {0}, ln: {1}, height: {2}, DOB: {3}", FirstName ?? String.Empty, LastName ?? String.Empty, 
                    HeightInches.HasValue ? HeightInches.Value.ToString() : "null", Dob.HasValue ? Dob.Value.ToShortDateString() : "null" );
            }
        }
    }
