    public class LastOffset
    {
        public string __invalid_name__$t { get; set; }
    }
    
    public class Option
    {
        public string __invalid_name__$t { get; set; }
    }
    public class Options
    {
        public List<Option> option { get; set; }
    }
    public class Breed
    {
        public string __invalid_name__$t { get; set; }
    }
    public class Breeds
    {
        public Breed breed { get; set; }
    }
    public class ShelterPetId
    {
    }
    public class Status
    {
        public string __invalid_name__$t { get; set; }
    }
    public class Name
    {
        public string __invalid_name__$t { get; set; }
    }
    public class Pet
    {
        public Options options { get; set; }
        public Breeds breeds { get; set; }
        public ShelterPetId shelterPetId { get; set; }
        public Status status { get; set; }
        public Name name { get; set; }
    }
    public class Pets
    {
        public List<Pet> pet { get; set; }
    }
    public class Petfinder
    {
        public string __invalid_name__@xmlns:xsi { get; set; }
        public LastOffset lastOffset { get; set; }
        public Pets pets { get; set; }
    }
    public class RootObject
    {
        public string __invalid_name__@encoding { get; set; }    
        public string __invalid_name__@version { get; set; }
        public Petfinder petfinder { get; set; }
    }
