    public class ResetPolicyData : ContainSagaData
    {
        public int NumberOfEmailsInGroup { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Dont reference directly. Only here for persisting data to Azurestorage. Use
        /// AddPasswordResetInformation/GetPasswordResetInformation instead.
        /// </summary>
        public string PasswordResetInformationJson { get; set; }
               
        #region Handle Searilize and Desearilize PasswordResetInformation 
        public void AddPasswordResetInformation(PasswordResetInformation value)
        {
            if (value == null) return;
            //Hydrate collection
            var collection = string.IsNullOrEmpty(PasswordResetInformationJson) ? 
                new List<PasswordResetInformation>() : JsonConvert.DeserializeObject<List<PasswordResetInformation>>(PasswordResetInformationJson);
            
            //Check is unique before adding
            if(!collection.Contains(value)) collection.Add(value);
            PasswordResetInformationJson = JsonConvert.SerializeObject(collection);
        }
        public List<PasswordResetInformation> GetPasswordResetInformation()
        {
            return string.IsNullOrEmpty(PasswordResetInformationJson) ? 
                new List<PasswordResetInformation>() : JsonConvert.DeserializeObject<List<PasswordResetInformation>>(PasswordResetInformationJson);
        }
        #endregion
    }
