    static IKernel kernel = new StandardKernel();
    void Main()
    {
    	//
    	// Automatic binding using 
    	// Ninject.Extensions.Conventions
        // Generally, you only want to declare your
        // DI container once in the application lifetime
        // Expecially in web apps, you will also need to 
        // consider the scope of bound classes, such as:
        //   Transient, Thread, Singleton, or Request
    	kernel.Bind(x=>x
    		.FromThisAssembly()
    		.SelectAllClasses()
    		.BindAllInterfaces()
    	);
        //
        // Now we can resolve the loader and run it
        // Compare this code to how it would look if you
        // manually instantiate all the dependencies and consider:
        // - How much additional code is there?
        // - How easy is it to perform unit tests on the various
        //   components (Mocking is useful here)?
        // - What is the effort if I need to swap out a service
        //   such as IMessageWriter?
        //
        // IMPORTANT: For example only. Do not use kernel.Get()
        // all over your code base.
        // This results in a ServiceLocator anti-pattern! 
    	ProcessRunner runner = kernel.Get<ProcessRunner>();
    	runner.Execute();
    }
    
    public interface IMessageWriter{
    	void Write(string message);
    }
    
    public class MessageWriter : IMessageWriter
    {
    	public void Write(string message){
    		Console.WriteLine ("MESSAGE: {0}", message);
    	}
    }
    
    public interface IProcessStep {
    	int Step{ get; }
    	void Execute();
    }
    
    public class ProcessRunner
    {
    	private readonly IEnumerable<IProcessStep> steps;
    	public ProcessRunner(IEnumerable<IProcessStep> steps)
    	{
    		this.steps = steps;		
    	}
    	
    	public void Execute(){
    		steps
    			.OrderBy (o => o.Step)
    			.ToList()
    			.ForEach(i=>i.Execute());
    	}
    }
    public class ProcessStep1 : IProcessStep
    {
    	private readonly IMessageWriter writer;
    	public ProcessStep1(IMessageWriter writer)
    	{
    		this.writer = writer;		
    	}
    	public int Step { get { return 10; }}
    	public void Execute(){
    		writer.Write("Hello from step1!");		
    	}
    }
    public class ProcessStep2 : IProcessStep
    {
    	private readonly IMessageWriter writer;
    	public ProcessStep2(IMessageWriter writer)
    	{
    		this.writer = writer;		
    	}
    	public int Step { get { return 20; }}
    	public void Execute(){
    		writer.Write("Hello from step2!");	
    	}
    }
    public class ProcessStep3 : IProcessStep
    {
    	private readonly IMessageWriter writer;
    	public ProcessStep3(IMessageWriter writer)
    	{
    		this.writer = writer;		
    	}
    	public int Step { get { return 30; }}
    	public void Execute(){
    		writer.Write("Hello from step3!");	
    	}
    }
