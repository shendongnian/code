		using System;
		using System.Threading;
		using System.Threading.Tasks;
		namespace Example
		{
			class OftenReadSometimesUpdate<T>
			{
				private Task<T> result_task = null;
				private SpinLock spin_lock = new SpinLock(false);
				private TResult LockedFunc<TResult>(Func<TResult> locked_func)
				{
					TResult t_result = default(TResult);
					bool gotLock = false;
					if (locked_func == null) return t_result;
					try
					{
						spin_lock.Enter(ref gotLock);
						t_result = locked_func();
					}
					finally
					{
						if (gotLock) spin_lock.Exit();
						gotLock = false;
					}
					return t_result;
				}
				public Task<T> GetComputationAsync()
				{
					return
					LockedFunc(GetComputationTaskLocked)
					;
				}
				public T GetComputationResult()
				{
					return
					LockedFunc(GetComputationTaskLocked)
					.Result
					;
				}
				public OftenReadSometimesUpdate<T> InvalidateComputationResult()
				{
					return
					this
					.LockedFunc(InvalidateComputationResultLocked)
					;
				}
				public OftenReadSometimesUpdate<T> InvalidateComputationResultLocked()
				{
					result_task = null;
					return this;
				}
				private Task<T> GetComputationTaskLocked()
				{
					if (result_task == null)
					{
						result_task = new Task<T>(HeavyComputation);
						result_task.Start(TaskScheduler.Default);
					}
					return result_task;
				}
				protected virtual T HeavyComputation()
				{
					//a heavy computation
					return default(T);//return some result of computation
				}
			}
        }
