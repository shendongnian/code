    var json = @"{'MessageCodes': {
      'Code1': 'Message 1',
      'Code2': 'Message 2',
      'Code3': 'Message 3',
      'Code4': 'Message 4',
      'Code5': 'Message 5',
      'Code6': 'Message 6'}}";
	var dict = JsonConvert.DeserializeObject<Test>(json);
    public class Test
    {
	    public Dictionary<string, string> MessageCodes { get; set; }
    }
