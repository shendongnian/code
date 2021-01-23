        class ProtoRecurseTest : ISerializationManagementCallbacks
        {
            private int nextPayload = 1;
            public int Payload { get; private set; } = 0;
            public ProtoRecurseTest Back { get; private set; } = null;
            public List<ProtoRecurseTest> Children { get; set; } = new List<ProtoRecurseTest>();
            public ProtoRecurseTest Add()
            {
                ProtoRecurseTest result = new ProtoRecurseTest(this, nextPayload++);
                Children.Add(result);
                return result;
            }
            public ProtoRecurseTest()
            {
            }
            private ProtoRecurseTest(ProtoRecurseTest parent, int payload)
            {
                Back = parent;
                this.Payload = payload;
                nextPayload = payload + 1;
            }
            private static void ToStringHelper(ProtoRecurseTest proto, StringBuilder sb)
            {
                sb.Append(proto.Payload + " -> ");
                // another little hassle of protobuf due to empty list -> null deserialization
                if (proto.Children != null)
                {
                    foreach (var child in proto.Children)
                        ToStringHelper(child, sb);
                }
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                ToStringHelper(this, sb);
                return sb.ToString();
            }
            static void PreSerializationHelper(ProtoRecurseTest instance)
            {
                instance.Back = null;
                foreach (var child in instance.Children)
                    PreSerializationHelper(child);
            }
            public void BeforeSerialization()
            {
                PreSerializationHelper(this);
            }
            static void PostDeserializationHelper(ProtoRecurseTest instance, ProtoRecurseTest parent)
            {
                if (instance.Children == null)
                    instance.Children = new List<ProtoRecurseTest>();
                instance.Back = parent;
                foreach (var child in instance.Children)
                    PostDeserializationHelper(child, instance);
            }
            public void AfterDeserialization()
            {
                PostDeserializationHelper(this, null);
            }
        }
