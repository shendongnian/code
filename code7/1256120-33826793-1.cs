    public override void ProcessInput(int InputID, Microsoft.SqlServer.Dts.Pipeline.PipelineBuffer buffer)
    {
        IDTSInput100 input = ComponentMetaData.InputCollection.GetObjectByID(InputID);
        while (buffer.NextRow())
        {
            for (int columnIndex = 0; columnIndex < input.InputColumnCollection.Count; columnIndex++)
            {
                IDTSInputColumn100 inputColumn = input.InputColumnCollection[columnIndex];
                var test = buffer[columnIndex];
            }
        }
    }
