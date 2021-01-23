c#
    private string CreateTaskConfigurationFile(string taskName, EquipmentEventExtended eventData, string host)
        {
            List<Change> changes = new List<Change>
            {
                new Change(MailConstants.EventName,eventData.EventName),
                new Change(MailConstants.Deadline, eventData.DateTo.Value.ToShortDateString()),
                new Change(MailConstants.EventDetails, eventData.EventDetails),
                new Change(MailConstants.Link,$"{host}/Inventory/Details/{eventData.InventoryId}")
            };
            MailTaskModel mtm = new MailTaskModel
            {
                Body = MailConstants.UpdateTemplate(MailConstants.TaskMailTemplate, changes),
                Subject = "[Reminder] Upcoming Event needs your attention",
                ToAddress = "abcdef@gmail.com",
                IsHtml = true
            };
            var fileName = string.Format(@"E:\{0}.json", taskName);
            using (StreamWriter file = File.CreateText(fileName))
            {
                JsonSerializer js = new JsonSerializer();
                js.Serialize(file, mtm);
            }
            return fileName;
        }
Then you provide the file path as an argument to the console application:
c#
static void Main(string[] args)
        {
            var configFilePath = args[0];
            var mailConfig = LoadConfigurationFile(configFilePath);
            MailManager manager = new MailManager(mailConfig.ToAddress, mailConfig.FromAddress,mailConfig.Subject, mailConfig.Body,mailConfig.IsHtml);
            manager.SendMail();
        }
        private static MailTaskModel LoadConfigurationFile(string configurationFilePath)
        {
            MailTaskModel mailConfig;
            using(var sr = new StreamReader(configurationFilePath))
            {
                string json = sr.ReadToEnd();
                mailConfig = JsonConvert.DeserializeObject<MailTaskModel>(json);
            }
            return mailConfig;
        }
You can then use something like 
ConsoleApplication.exe -yourFilePath
I've removed noisy check-ups for nulls and all that so that it's more clear.
