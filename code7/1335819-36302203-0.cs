	<UsingTask TaskName="ParseUnsupressedAnalysisIssues" TaskFactory="CodeTaskFactory" AssemblyFile="$(MSBuildToolsPath)\Microsoft.Build.Tasks.v4.0.dll" >
		<ParameterGroup>
			<Files ParameterType="Microsoft.Build.Framework.ITaskItem[]" Required="true" />
			<Result ParameterType="Microsoft.Build.Framework.ITaskItem[]" Output="true" />
		</ParameterGroup>
		<Task>
			<Reference Include="System.Runtime.Serialization" />
			<Reference Include="System.Xml" />
			<Reference Include="System.Xml.Linq" />
			<Using Namespace="System"/>
			<Using Namespace="System.Collections.Generic"/>
			<Using Namespace="System.IO"/>
			<Using Namespace="System.Linq"/>
			<Using Namespace="System.Runtime.Serialization.Json"/>
			<Using Namespace="System.Xml"/>
			<Using Namespace="System.Xml.Linq"/>
			<Code Type="Fragment" Language="cs">
				<![CDATA[
				List<TaskItem> taskItems = new List<TaskItem>();
				foreach(ITaskItem item in Files)
				{
					try
					{
						string path = item.GetMetadata("FullPath");
						using (FileStream fs = new FileStream(path, FileMode.Open))
						using (XmlDictionaryReader reader = JsonReaderWriterFactory.CreateJsonReader(fs, XmlDictionaryReaderQuotas.Max))
						{
							XElement doc = XElement.Load(reader);
							XElement issuesRoot = doc.Elements("issues").SingleOrDefault();
							List<XElement> unsupressedIssues = issuesRoot.Elements("item").Where(e => !"True".Equals((string)e.Element("properties").Element("isSuppressedInSource"), StringComparison.Ordinal)).ToList();
							string unsupressedIssuesString = string.Join(Environment.NewLine, unsupressedIssues);
							if(!string.IsNullOrEmpty(unsupressedIssuesString))
							{
								taskItems.Add(new TaskItem(item.ItemSpec));
								Console.WriteLine(unsupressedIssuesString);
							}
						}
					}
					catch(Exception e)
					{
						taskItems.Add(new TaskItem(item.ItemSpec));
						Console.WriteLine(e.ToString());
					}
				}
				Result = taskItems.ToArray();
				]]>
			</Code>
		</Task>
	</UsingTask>
