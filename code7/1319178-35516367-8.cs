    public class State<TState, TResult>
    {
    	private readonly Func<TState, StateResult<TState, TResult>> f;
    
    	public State(Func<TState, StateResult<TState, TResult>> f)
    	{
    		this.f = f;
    	}
    
    	public StateResult<TState, TResult> Run(TState state)
    	{
    		return this.f(state);
    	}
    
    	public TResult RunResult(TState state)
    	{
    		return this.f(state).Result;
    	}
    
    	public TState RunState(TState state)
    	{
    		return this.f(state).State;
    	}
    
    	public State<TState, TOut> Select<TOut>(Func<TResult, TOut> mapFunc)
    	{
    		Contract.Requires(mapFunc != null);
    
    		return new State<TState, TOut>(s =>
    		{
    			var thisResult = this.f(s);
    			return new StateResult<TState, TOut>(s, mapFunc(thisResult.Result));
    		});
    	}
    
    	public State<TState, TOut> BiSelect<TOut>(Func<StateResult<TState, TResult>, StateResult<TState, TOut>> mapFunc)
    	{
    		return new State<TState, TOut>(s =>
    		{
    			return mapFunc(this.f(s));
    		});
    	}
    
    	public State<TState, TOut> SelectMany<TOut>(Func<TResult, State<TState, TOut>> bindFunc)
    	{
    		return SelectMany(bindFunc, (_, r) => r);
    	}
    
    	public State<TState, TOut> SelectMany<TInter, TOut>(Func<TResult, State<TState, TInter>> bindFunc, Func<TResult, TInter, TOut> selector)
    	{
    		return new State<TState, TOut>(initialState =>
    		{
    			var thisResult = this.f(initialState);
    			var nextState = bindFunc(thisResult.Result);
    			var nextResult = nextState.Run(thisResult.State);
    			var result = selector(thisResult.Result, nextResult.Result);
    			return new StateResult<TState, TOut>(nextResult.State, result);
    		});
    	}
    }
    
    public static class State
    {
    	public static State<TState, TResult> FromResult<TState, TResult>(TResult result)
    	{
    		return new State<TState, TResult>(s => new StateResult<TState, TResult>(s, result));
    	}
    
    	public static State<TState, TState> Get<TState>()
    	{
    		return new State<TState, TState>(s => new StateResult<TState, TState>(s, s));
    	}
    
    	public static State<TState, Unit> Put<TState>(TState state)
    	{
    		return new State<TState, Unit>(_ => new StateResult<TState, Unit>(state, Unit.Instance));
    	}
    
    	public static State<TState, Unit> Modify<TState>(Func<TState, TState> modifyFunc)
    	{
    		return from s in Get<TState>()
    			   from _ in Put(modifyFunc(s))
    			   select Unit.Instance;
    	}
    }
    
    public struct StateResult<TState, TResult>
    {
    	public StateResult(TState state, TResult result)
    		: this()
    	{
    		this.State = state;
    		this.Result = result;
    	}
    
    	public TState State { get; private set; }
    	public TResult Result { get; private set; }
    }
