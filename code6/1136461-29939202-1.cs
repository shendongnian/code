	Channel[] channels = new Channel[3];
	channels[0] = new Channel
	{
		Axis = "channel1",
		Times = new[] { 1f, 2f, 3f, 4f, 5f, 6f }
	};
	channels[1] = new Channel
	{
		Axis = "channel1",
		Times = new[] { 0f, 2f, 2.5f, 3f, 5f, 6f }
	};
	channels[2] = new Channel
	{
		Axis = "channel1",
		Times = new[] { 1f, 2.5f, 3f, 4f, 5.5f, 6f }
	};
	MiniChannel miniChannel0 = new MiniChannel {Axis = channels[0].Axis, Value = channels[0].Times[0]};
	MiniChannel miniChannel1 = new MiniChannel {Axis = channels[1].Axis, Value = channels[1].Times[0]};
	MiniChannel miniChannel2 = new MiniChannel {Axis = channels[2].Axis, Value = channels[2].Times[0]};
	List<MiniChannel> list = new List<MiniChannel>
	{
		miniChannel0, miniChannel1, miniChannel2
	};
	var result = from minichannel in list
		group minichannel by minichannel.Value
		into g
		select new {Value = g.Key, Items = g};
	Dictionary<float, MiniChannel[]> dict = result.ToDictionary(key => key.Value, value => value.Items.Select(x => x).ToArray());
