       //--------------------------------------------------------------// Press F1 to get help about using script.// To access an object that is not located in the current class, start the call with Globals.// When using events and timers be cautious not to generate memoryleaks,// please see the help for more information.//---------------------------------------------------------------namespace Neo.ApplicationFramework.Generated{
    using System.Windows.Forms;
    using System;
    using System.Drawing;
    using Neo.ApplicationFramework.Tools;
    using Neo.ApplicationFramework.Common.Graphics.Logic;
    using Neo.ApplicationFramework.Controls;
    using Neo.ApplicationFramework.Interfaces;
    public partial class ConversionMath
    {
    static ConversionMath()
    
    {   
    
    Globals.Tags.Tank01_Product_Level_EU.Value = 177.66;
    Globals.Tags.Tank05_Product_Level_EU.Value = 377.66;
    Globals.Tags.Tank07_Product_Level_EU.Value = 147.66;
    Globals.Tags.Tank09_Product_Level_EU.Value = 257.66;
    Globals.Tags.Tank16_Product_Level_EU.Value = 67.66;
    Globals.Tags.Tank01_Total_Capacity.Value = 300; 
    
    Globals.Tags.Tank01_Interface_Level_EU.Value = 8.66;
    Globals.Tags.Tank05_Interface_Level_EU.Value = 90.66;
    Globals.Tags.Tank01_Interface_Level_EU.Value = 142.66;
    Globals.Tags.Tank09_Interface_Level_EU.Value = 253.66;
    Globals.Tags.Tank16_Interface_Level_EU.Value = 64.66;
    
    Globals.Tags.Tank01_Product_Level_DISP.Value = ConversionMath.LevelConverter(Globals.Tags.Tank01_Product_Level_EU.Value);
    Globals.Tags.Tank02_Product_Level_DISP.Value = ConversionMath.LevelConverter(Globals.Tags.Tank02_Product_Level_EU.Value);
    
    //Interface Levels  
    Globals.Tags.Tank01_Interface_Level_DISP.Value = ConversionMath.LevelConverter(Globals.Tags.Tank01_Interface_Level_EU.Value);
    Globals.Tags.Tank02_Interface_Level_DISP.Value = ConversionMath.LevelConverter(Globals.Tags.Tank02_Interface_Level_EU.Value);
    
    Globals.Tags.Tank01_Total_Capacity.Value = 300; 
    Globals.Tags.Tank01_Avail_Vol.Value = ConversionMath.AvailPct(Globals.Tags.Tank01_Total_Capacity.Value, Globals.Tags.Tank01_Product_Level_EU.Value );
    
    }   
    
    public static string LevelConverter(float Product_Level_EU )
    {
    float fFT = Product_Level_EU / 12;
    int levelFT = (int)fFT;
    float levelIN = Product_Level_EU - levelFT * 12;
    string Product_Level_Disp = levelFT.ToString() + "'" + " " + levelIN.ToString() + '"';
    return Product_Level_Disp;
    }
    public static float AvailPct(float TotalCapacity, float TankVol)
    {
    float AvailPCT = (TankVol / TotalCapacity) * 100 ;  
    return AvailPCT;
    }   
    
    }
    
    }
