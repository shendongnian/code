        private draw(Canvas canvas)
        {
          RectF centerRect = new RectF(....); // change to your values
    
          drawCenterRect(canvas);
      
          canvas.save();
          canvas.clipRect(centerRect, Region.Op.DIFFERENCE); // lets draw everywhere except center rect
          drawItems(canvas, Color.BLACK); // Pass color outside selection
          canvas.restore();
    
          canvas.save();
          canvas.clipRect(centerRect, Region.Op.REPLACE); // lets draw inside center rect only
          drawItems(canvas, Color.WHITE); // Pass color inside selection
          canvas.restore();
        }
