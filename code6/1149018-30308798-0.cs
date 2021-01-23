    pipeline.InvokeAsync();
    pipeline.Output.WaitHandle.WaitOne(1000);
    if(pipeline.PipelineStateInfo.State == PipelineState.Completed) {
        stdout.AddRange(pipeline.Output.ReadToEnd());
    }
