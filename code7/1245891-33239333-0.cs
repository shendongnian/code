         Index: source/ZedGraph/ZedGraphControl.Events.cs
     ===================================================================
     --- source/ZedGraph/ZedGraphControl.Events.cs	(revision 451)
     +++ source/ZedGraph/ZedGraphControl.Events.cs	(working copy)
     @@ -713,15 +713,19 @@
      				{
      					if ( nearestObj is CurveItem && iPt >= 0 )
      					{
     -						CurveItem curve = (CurveItem)nearestObj;
     +						CurveItem curve = (CurveItem)nearestObj;
     +                        string label = "";
      						// Provide Callback for User to customize the tooltips
      						if ( this.PointValueEvent != null )
      						{
     -							string label = this.PointValueEvent( this, pane, curve, iPt );
     +							label = this.PointValueEvent( this, pane, curve, iPt );
      							if ( label != null && label.Length > 0 )
     -							{
     -								this.pointToolTip.SetToolTip( this, label );
     -								this.pointToolTip.Active = true;
     +							{
     +                                if ( this.pointToolTip.GetToolTip( this ) != label )
     +                                {
     +                                    this.pointToolTip.SetToolTip( this, label );
     +                                    this.pointToolTip.Active = true;
     +                                }
      							}
      							else
      								this.pointToolTip.Active = false;
     @@ -730,9 +734,8 @@
      						{
      
      							if ( curve is PieItem )
     -							{
     -								this.pointToolTip.SetToolTip( this,
     -									( (PieItem)curve ).Value.ToString( _pointValueFormat ) );
     +							{
     +                                label = ( (PieItem)curve ).Value.ToString( _pointValueFormat );
      							}
      							//							else if ( curve is OHLCBarItem || curve is JapaneseCandleStickItem )
      							//							{
     @@ -750,7 +753,7 @@
      								PointPair pt = curve.Points[iPt];
      
      								if ( pt.Tag is string )
     -									this.pointToolTip.SetToolTip( this, (string)pt.Tag );
     +									label = (string)pt.Tag;
      								else
      								{
      									double xVal, yVal, lowVal;
     @@ -766,14 +769,18 @@
      									string yStr = MakeValueLabel( curve.GetYAxis( pane ), yVal, iPt,
      										curve.IsOverrideOrdinal );
      
     -									this.pointToolTip.SetToolTip( this, "( " + xStr + ", " + yStr + " )" );
     +									label = string.Format( "( {0}, {1} )", xStr, yStr );
      
      									//this.pointToolTip.SetToolTip( this,
      									//	curve.Points[iPt].ToString( this.pointValueFormat ) );
      								}
     -							}
     -
     -							this.pointToolTip.Active = true;
     +							}
     +
     +                            if ( this.pointToolTip.GetToolTip( this ) != label )
     +                            {
     +                                this.pointToolTip.SetToolTip( this, label );
     +                                this.pointToolTip.Active = true;
     +                            }
      						}
      					}
      					else
     @@ -791,15 +798,19 @@
      		{
      			GraphPane pane = _masterPane.FindPane( mousePt );
      			if ( pane != null && pane.Chart._rect.Contains( mousePt ) )
     -			{
     +			{
     +                string label = "";
      				// Provide Callback for User to customize the tooltips
      				if ( this.CursorValueEvent != null )
      				{
     -					string label = this.CursorValueEvent( this, pane, mousePt );
     +					label = this.CursorValueEvent( this, pane, mousePt );
      					if ( label != null && label.Length > 0 )
     -					{
     -						this.pointToolTip.SetToolTip( this, label );
     -						this.pointToolTip.Active = true;
     +					{
     +                        if ( this.pointToolTip.GetToolTip( this ) != label )
     +                        {
     +                            this.pointToolTip.SetToolTip( this, label );
     +                            this.pointToolTip.Active = true;
     +                        }
      					}
      					else
      						this.pointToolTip.Active = false;
     @@ -812,8 +823,12 @@
      					string yStr = MakeValueLabel( pane.YAxis, y, -1, true );
      					string y2Str = MakeValueLabel( pane.Y2Axis, y2, -1, true );
      
     -					this.pointToolTip.SetToolTip( this, "( " + xStr + ", " + yStr + ", " + y2Str + " )" );
     -					this.pointToolTip.Active = true;
     +                    label = string.Format(  "( {0}, {1}, {2} )", xStr, yStr, y2Str );
     +					if ( this.pointToolTip.GetToolTip( this ) != label )
     +                    {
     +                        this.pointToolTip.SetToolTip( this, "( " + xStr + ", " + yStr + ", " + y2Str + " )" );
     +					    this.pointToolTip.Active = true;
     +                    }
      				}
      			}
      			else
     
