    public class EmitterStuff
    {
        public static void Main(string[] args)
        {
            Dictionary<string, object> toSerialize = new Dictionary<string, object>();
            // Add values
    
    
            // Use following code as an example to serialize the in-memory data
            string yaml;
            using (TextWriter output = new StringWriter())
            {
                IEmitter emitter = new Emitter(output);
                emitter.Emit(new DocumentStart());
                WriteYamlObject(emitter, toSerialize);
                emitter.Emit(new DocumentEnd(false));
                yaml = output.ToString();
            }
    
            // result is in yaml
        }
    
        private static void WriteYamlObject(IEmitter emitter, object obj)
        {
            if (obj is IDictionary<string, object>)
            {
                emitter.Emit(new MappingStart());
    
                var dict = (IDictionary<string, object>) obj;
                foreach (KeyValuePair<string, object> pair in dict)
                {
                    emitter.Emit(new Scalar(pair.Key));
                    WriteYamlObject(emitter, pair.Value);
                }
    
                emitter.Emit(new MappingEnd());
            }
            else if (obj is ICollection<object>)
            {
                emitter.Emit(new SequenceStart());
    
                var coll = (ICollection<object>) obj;
                foreach (object value in coll)
                {
                    WriteYamlObject(emitter, value);
                }
    
                emitter.Emit(new SequenceEnd());
            }
            else
            {
                // You probably should have some special cases here.
                emitter.Emit(new Scalar(obj.ToString()));
            }
        }
    }
