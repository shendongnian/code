	private void EnsureGeometry()
	{
	    if (this.textGeometry != null) {
	        return;
	    }
	
	    this.EnsureFormattedText();
	    var originalGeometry = this.formattedText.BuildGeometry(new Point(0, 0));
	    
	    if (MergeShapes) {
	      PathGeometry newGeo = new PathGeometry();
	      foreach (var pg in FindAllPathGeometries(originalGeometry)) {
	      	newGeo = Geometry.Combine(newGeo, pg, GeometryCombineMode.Union, null);
	      }
	      
	      this.textGeometry = newGeo;
	    } else {
	    	this.textGeometry = originalGeometry;
	    }
	}
	
	public static readonly DependencyProperty MergeShapesProperty = DependencyProperty.Register("MergeShapes",
	                                                                                            typeof(bool),
	                                                                                            typeof(OutlinedTextBlock),
	                                                                                            new FrameworkPropertyMetadata(OnFormattedTextUpdated));
	
	public bool MergeShapes {
		get {
			return (bool)GetValue(MergeShapesProperty);
		}
		set {
			SetValue(MergeShapesProperty, value);
		}
	}
