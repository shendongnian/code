    // Replace the return type "object" with the type you expect returned from the Average call
    // Replace the "object" in 'this object @this' with the type of 'ag' in the lambda 'h.Aggregations(ag => ag'
    public static object AverageChannels(this object @this, int channelCount) // alternatively, obtain the channel count from the input variable if this can be done
    {
        if (channelCount < 1)
        {
          // do something
        }
        var result = @this.Average("avg1", b => b.Field("channel1");
        for (int i = 2; i < channelCount + 1; i++)
        {
            var avgText = "avg" + i.ToString();
            var channelText = "channel" + i.ToString();
            result = result .Average(avgText, b => b.Field(channelText))
        }
        return result;
    }
