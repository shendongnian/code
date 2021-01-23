Consider storing all your Command objects in something like a Dictionary&lt;CommandGroups, List&lt;Command&gt;&gt;. Then, assuming your Command class has a Name property on it that exposes the verbs such as "about", "kick", "ban", etc., you could do:
// assuming "groups" is the dictionary:
foreach (var kvp in groups)
{
  Console.WriteLine("{0}: {1}", kvp.Key, string.Join(", ", kvp.Value.Select(x => x.Name).ToArray()));
}
