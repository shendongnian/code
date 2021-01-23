var config = "#comment1\r\naccount.1.enable = 1\r\naccount.1.label = Front";
var configConvert = new ConfigConvert();
var item = configConvert.DeserializeObject<AccountCollection>(config);
public class AccountCollection
{
    [ConfigKey("account.")]
    [ConfigArray]
    public Account[] Accounts { get; set; }
}
public class Account : ConfigArrayElement
{
    public int Enable { get; set; }
    public string Label { get; set; }
    [ConfigKey("display_name")]
    public string DisplayName { get; set; }
}
