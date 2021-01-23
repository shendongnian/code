    private static void InsertNote(int pitch, int velocity, int position, int duration, int channel, ref List<Tuple<int, bool, ChannelMessage>> messages)
    {
        ChannelMessageBuilder builder = new ChannelMessageBuilder();
        builder.Command = ChannelCommand.NoteOn;
        builder.Data1 = pitch;
        builder.Data2 = velocity;
        builder.MidiChannel = channel;
        builder.Build();
        messages.Add(new Tuple<int, bool, ChannelMessage>(position, true, builder.Result));
        builder.Command = ChannelCommand.NoteOff;
        builder.Data1 = pitch;
        builder.Data2 = velocity;
        builder.MidiChannel = channel;
        builder.Build();
        messages.Add(new Tuple<int, bool, ChannelMessage>(position + duration, false, builder.Result));
    }
