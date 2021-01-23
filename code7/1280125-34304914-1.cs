    public class Conductor
    {
    	private IPlotterHelper _plotter_helper = new PlotterHelper();
    
    	private IFileWriterHelper _file_writer_helper = new FileWriterHelper();
    
    	public void Conduct()
    	{
    		_file_writer_helper.ProcessFrame();
    		_file_writer_helper.RunCommand();
    		_plotter_helper.ProcessSamples();
    		_plotter_helper.RunCommand();
    	}
    }
    
    internal interface IHelper
    {
    	void RunCommand();
    }
    
    internal interface IFileWriterHelper : IHelper
    {
    	void ProcessFrame();
    }
    
    internal interface IPlotterHelper : IHelper
    {
    	void ProcessSamples();
    }
    
    
    internal class FileWriterHelper : Helper, IFileWriterHelper
    {
    	public void ProcessFrame()
    	{
    	}
    }
    
    internal class PlotterHelper : Helper, IPlotterHelper
    {
    	public void ProcessSamples()
    	{
    	}
    }
    
    internal class Helper : IHelper
    {
    	public void RunCommand()
    	{
    	}
    }
