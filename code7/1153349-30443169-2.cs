    public abstract class ParameterKeyOrValue<T>
    {
        [XmlText]
        public T Text { get; set; }
    }
    public sealed class ParameterKey<T> : ParameterKeyOrValue<T>
    {
    }
    public sealed class ParameterValue<T> : ParameterKeyOrValue<T>
    {
    }
    [Serializable]
    [XmlType("parameters")]
    public class parameters
    {
        [XmlIgnore]
        public List<parameter<string, string>> parameter { get; set; }
        [XmlArray("parameter")]
        [XmlArrayItem("key", typeof(ParameterKey<string>))]
        [XmlArrayItem("value", typeof(ParameterValue<string>))]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ParameterKeyOrValue<string>[] XmlParameters
        {
            get
            {
                if (parameter == null)
                    return null;
                return parameter.SelectMany(p => new ParameterKeyOrValue<string>[] { new ParameterKey<string> { Text = p.key }, new ParameterValue<string> { Text = p.value } }).ToArray();
            }
            set
            {
                if (value == null)
                    parameter = null;
                else
                {
                    if (value.Length % 2 != 0)
                        throw new ArgumentException("Unequal number of keys and values");
                    var newParameters = value.OfType<ParameterKey<string>>().Zip(value.OfType<ParameterValue<string>>(), (k, v) => new parameter<string, string>(k.Text, v.Text)).ToList();
                    // Make sure we got an equal number of keys and values.
                    if (newParameters.Count != value.Length / 2)
                        throw new ArgumentException("Unequal number of keys and values");
                    parameter = newParameters;
                }
            }
        }
    }
