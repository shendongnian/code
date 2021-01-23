    #addin "nuget:https://www.nuget.org/api/v2?package=Newtonsoft.Json"
    using Newtonsoft.Json;
    public class MissingPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    var john = new MissingPerson {
        FirstName = "John",
        LastName = "Doe"
    };
    // Serialize and output MissingPerson as json
    Information(
        "MissingPerson as json: {0}",
        JsonConvert.SerializeObject(john, Formatting.Indented)
        );
    /*
     * This will output
     * MissingPerson as json: {
     *   "FirstName": "John",
     *   "LastName": "Doe"
     * }
     */
    var jsonMissingPerson = "{\"FirstName\": \"Jane\",\"LastName\": \"Doe\"}";
    // Deserialize json string to object
    var jane = JsonConvert.DeserializeObject<MissingPerson>(jsonMissingPerson);
    Information(
        "Missing Person from json:\r\n\tFirstName: {0}\r\n\tLastName: {1}",
        jane.FirstName,
        jane.LastName
        );
    /*
     * This will output
     * Missing Person from json:
     *        FirstName: Jane
     *        LastName: Doe
     */
