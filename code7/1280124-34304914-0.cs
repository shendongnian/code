	public class Conductor
	{
		private IPlotterHelper _plotter_helper = new PlotterHelper();
	
		private IFileWriterHelper _file_writer_helper = new FileWriterHelper();
	
		public void Conduct()
		{
			_file_writer_helper.ProcessFrame();
			_plotter_helper.ProcessSamples();
		}
	}
	
	internal interface IFileWriterHelper
	{
		void ProcessFrame();
	}
	
	internal interface IPlotterHelper
	{
		void ProcessSamples();
	}
	
	
	internal class FileWriterHelper : Helper, IFileWriterHelper
	{
		public void ProcessFrame()
	    {
	        base.RunCommand();
	    }
	}
	
	internal class PlotterHelper : Helper, IPlotterHelper
	{
		public void ProcessSamples()
		{
			base.RunCommand();
		}
	}
	
	internal class Helper
	{
		protected void RunCommand()
		{
		}
	}
