    using System;
    using System.Linq;
    using System.IO;
    using System.Xml.Serialization;
    using System.Collections.ObjectModel;
    
    public class OptimizationVariables
    {
        public string VariableName { get; set; }
    }
    public class OptimizationVariables_NewClass
    {
        public string VariableName { get; set; }
    }
    public class ModelsCollection
    {
    private ModelsCollection()
    {
    }
    private ObservableCollection<OptimizationVariables> m_optimizationVariables =
      new ObservableCollection<OptimizationVariables>();
    public ObservableCollection<OptimizationVariables> OptimizationVariables
    {
        get { return m_optimizationVariables; }
        set { m_optimizationVariables = value; }
    }
    private ObservableCollection<OptimizationVariables_NewClass> m_optimizationVariables_NewClass =
      new ObservableCollection<OptimizationVariables_NewClass>();
    public ObservableCollection<OptimizationVariables_NewClass> OptimizationVariables_NewClass
    {
        get { return m_optimizationVariables_NewClass; }
        set { m_optimizationVariables_NewClass = value; }
    }
    }
    class Program
    {
    static void Main(string[] args)
    {
        Serialize();
        Deserialize();
        Deserialize2NewClass();
    }
    static void Serialize()
    {
        ObservableCollection<OptimizationVariables> OptimizationVariables2Serialize = new ObservableCollection<OptimizationVariables>();
        OptimizationVariables opt_var1 = new OptimizationVariables();
        opt_var1.VariableName = "Variable Name 1";
        OptimizationVariables2Serialize.Add(opt_var1);
        OptimizationVariables opt_var2 = new OptimizationVariables();
        opt_var1.VariableName = "Variable Name 2";
        OptimizationVariables2Serialize.Add(opt_var1);
        TextWriter writer = new StreamWriter("XML_File.xml");
        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<OptimizationVariables>));
        serializer.Serialize(writer, OptimizationVariables2Serialize);
        writer.Close();
    }
    static void Deserialize()
    {
        TextReader sw = new StreamReader("XML_File.xml");
        ObservableCollection<OptimizationVariables> OptimizationVariablesDeserialized = new ObservableCollection<OptimizationVariables>();
        XmlSerializer deserializer = new XmlSerializer(typeof(ObservableCollection<OptimizationVariables>));
        OptimizationVariablesDeserialized = (ObservableCollection<OptimizationVariables>)deserializer.Deserialize(sw);
        Console.Write(OptimizationVariablesDeserialized.Count());
        sw.Close();
    }
    static void Deserialize2NewClass()
    {
        TextReader sw = new StreamReader("XML_File.xml");
        var str = sw.ReadToEnd();
        sw.Close();
        str = str.Replace("OptimizationVariables", "OptimizationVariables_NewClass");
        var stream = new StringReader(str);
        ObservableCollection<OptimizationVariables_NewClass> OptimizationVariablesDeserialized = new ObservableCollection<OptimizationVariables_NewClass>();
        XmlSerializer deserializer = new XmlSerializer(typeof(ObservableCollection<OptimizationVariables_NewClass>));
        OptimizationVariablesDeserialized = (ObservableCollection<OptimizationVariables_NewClass>)deserializer.Deserialize(stream);
        Console.Write(OptimizationVariablesDeserialized.Count());
    }
    }
