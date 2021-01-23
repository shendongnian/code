    [DataContract(Name = "DADOS")]
    public class Dados
    {
        [IgnoreDataMember]
        public DateTime? DtNascimento { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "NASCIMENTO")]
        string DtNascimentoString
        {
            get
            {
                if (DtNascimento == null)
                    return string.Empty;
                return XmlConvert.ToString(DtNascimento.Value, XmlDateTimeSerializationMode.RoundtripKind);
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    DtNascimento = null;
                else
                    DtNascimento = XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.RoundtripKind);
            }
        }
    }
