    [Serializable]
    public class GetUserCredentialDetailsReturn
    {
        public StatusReturn status { get; set; }
        public List<CredDetailsReturn> listOfCredDetails { get; set; }
    }
    JsonConvert.Deserialize<GetUserCredentialDetailsReturn>(json_string)
