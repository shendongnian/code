    public class Line_Interpolate : Steema.TeeChart.Samples.BaseForm
    {
    	private Steema.TeeChart.Styles.Line line1;
    	private Steema.TeeChart.Styles.Line line2;
    	private Steema.TeeChart.Styles.Line line3;
    	private Steema.TeeChart.Tools.CursorTool cursorTool1;
    	private System.Windows.Forms.CheckBox checkBox1;
    	private System.ComponentModel.IContainer components = null;
    	private Steema.TeeChart.Tools.GridBand gridBand1;
    	private double xval;
    
    	/// <summary>
    	/// Calculate y=y(x) for arbitrary x. Works fine only for line series with ordered x values.
    	/// </summary>
    	/// <param name="series"></param>
    	/// <param name="firstindex"></param>
    	/// <param name="lastindex"></param>
    	/// <param name="xvalue"></param>
    	/// <returns>y=y(xvalue) where xvalue is arbitrary x value.</returns>
    	private double InterpolateLineSeries(TeeChart.Styles.Custom series, int firstindex, int lastindex, double xvalue)
    	{
    	  int index;
    	  for (index=firstindex; index<=lastindex; index++)
    	  {
    		if (index == -1 || series.XValues.Value[index]>xvalue) break;
    	  }
    	  // safeguard
    	  if (index<1) index = 1;
    	  else if (index>=series.Count) index = series.Count -1;
    	  // y=(y2-y1)/(x2-x1)*(x-x1)+y1
    	  double dx = series.XValues[index] - series.XValues[index-1];
    	  double dy = series.YValues[index] - series.YValues[index-1];
    	  if (dx!=0.0) return dy*(xvalue - series.XValues[index-1])/dx + series.YValues[index-1];
    	  else return 0.0;
    	}
    
    	private double InterpolateLineSeries(TeeChart.Styles.Custom series,double xvalue)
    	{
    	  return InterpolateLineSeries(series,series.FirstVisibleIndex,series.LastVisibleIndex,xvalue);
    	}
    
    	public Line_Interpolate()
    	{
    		// This call is required by the Windows Form Designer.
    		InitializeComponent();
    
    		foreach (TeeChart.Styles.Series s in tChart1.Series)
    	s.FillSampleValues(20);
    	}
    
    	/// <summary>
    	/// Clean up any resources being used.
    	/// </summary>
    	protected override void Dispose( bool disposing )
    	{
    		if( disposing )
    		{
    			if (components != null) 
    			{
    				components.Dispose();
    			}
    		}
    		base.Dispose( disposing );
    	}
    
    	private void cursorTool1_Change(object sender, Steema.TeeChart.Tools.CursorChangeEventArgs e)
    	{
    	  xval = e.XValue;
    	  tChart1.Header.Text = "";
    	  for (int i=0; i<tChart1.Series.Count; i++)
    		if (tChart1.Series[i] is TeeChart.Styles.Custom)
    		{
    		  tChart1.Header.Text += tChart1.Series[i].Title + ": Y("+e.XValue.ToString("0.00")+")= ";
    		  tChart1.Header.Text += InterpolateLineSeries(tChart1.Series[i] as Steema.TeeChart.Styles.Custom,e.XValue).ToString("0.00")+"\r\n";
    		}
    	}
    
    	private void Line_Interpolate_Load(object sender, System.EventArgs e)
    	{
    	  cursorTool1_Change(tChart1,new Steema.TeeChart.Tools.CursorChangeEventArgs());
    	}
    
    	private void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
    	{
    	  if (checkBox1.Checked)
    	  {
    		int xs = tChart1.Axes.Bottom.CalcXPosValue(xval);
    		int ys;
    		g.Brush.Visible = true;
    		g.Brush.Solid = true;
    		for (int i=0; i<tChart1.Series.Count; i++)
    		  if (tChart1.Series[i] is TeeChart.Styles.Custom)
    		  {
    			ys = tChart1.Series[i].GetVertAxis.CalcYPosValue(InterpolateLineSeries(tChart1.Series[i] as Steema.TeeChart.Styles.Custom,xval));
    			g.Brush.Color = tChart1.Series[i].Color;
    			g.Ellipse(new Rectangle(xs-4,ys-4,8,8));
    		  }
    	  }
    	}
    }
