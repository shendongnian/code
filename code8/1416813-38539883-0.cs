    namespace System.Reactive.Linq.ObservableImpl
    {
    	internal class Timer : Producer<long>
    	{
    		protected override IDisposable Run(
                                   IObserver<long> observer, 
                                   IDisposable cancel, 
                                   Action<IDisposable> setSink)
    		{
    			if (this._period.HasValue)
    			{
    				Timer.TimerImpl timerImpl = 
                        new Timer.TimerImpl(this, observer, cancel);
    				
    				setSink(timerImpl);
    				return timerImpl.Run();
    			}
    			
    			...
    		}
    	}
    }
