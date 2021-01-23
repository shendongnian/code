    class CPanel
    {
    private:
      int m_Width;  // Private member for Width property
      int m_Height; // Private member for Height property
    
    protected:
      void __fastcall SetWidth(int AValue); // Set the Width property  
      int __fastcall  GetWidth();           // Get the Width property
    
      void __fastcall SetHeight(int AValue);// Set the Height property
      int  __fastcall GetHeight();          // Get the Height property
    
    public:
      CPanel()
      :Width(this), Height(this)
      {
      }
    
      CProperty<CPanel, int, SetWidth,  GetWidth>  Width;
      CProperty<CPanel, int, SetHeight, GetHeight> Height;
    }
