    var ser = new XmlSerializer(typeof(Activity));
    var activity = (Activity)ser.Deserialize(new StringReader(xml));
    System.Console.WriteLine(activity.ActionID);
    System.Console.WriteLine(activity.ActionLogSummary);
    System.Console.WriteLine(activity.type);
