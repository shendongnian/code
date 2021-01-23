    var copyInProgress = Copy(@"c:\temp\test2.bin", @"c:\temp\test.bin", 60);
    copyInProgress.ContinueWith(
            _ => { Console.WriteLine("cancelled.."); },
            TaskContinuationOptions.OnlyOnCanceled
        );
    copyInProgress.ContinueWith(
            _ => { Console.WriteLine("finished.."); },
            TaskContinuationOptions.OnlyOnRanToCompletion
        );
    copyInProgress.ContinueWith(
            _ => { Console.WriteLine("failed.."); },
            TaskContinuationOptions.OnlyOnFaulted
        );
    copyInProgress.Wait();
