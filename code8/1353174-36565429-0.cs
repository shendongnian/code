    [ProtoContract]
    class InputState {
        [ProtoMember(1)]
        public uint Input {get;set;}
        [ProtoMember(2)]
        public string state {get;set;}
    }
    [ProtoContract]
    class InputStateData {
        [ProtoMember(1)]
        public List<InputState> Input {get;} = new List<InputState>();
    }
