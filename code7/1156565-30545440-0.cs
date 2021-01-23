    [DataContract]
    public class Person
    {
        // this is plain data. It can be transfered back and forth,
        // other languages and frameworks will have no problem 
        // building proxy classes for it
        [DataMember]
        public int Age { get; set; }
    
        // this is not data. There is no data, there only is a calculation. 
        // That's logic. Logic cannot be transfered. Lets say your age is 18, 
        // then this is 19. But the point that this is not a fixed value of 19, 
        // but actually Age + 1, cannot be transfered. It's not data. It should 
        // not be part of the contract if you want this to be usable as a 
        // generic web service.
        [DataMember]
        public int AgeNextYear
        {
            get { return Age + 1; }
        }
    }
