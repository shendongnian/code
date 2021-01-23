    Public Class vw_Source_Columns 
        Inherits  vw_UI_List_Search_Columns
    	
        Public Property strDataViewName As String
        Public Property intColumnID As Integer
        Public Property intMaster As Integer
    End Class
    
    Public Class vw_UI_List_Search_Columns
        Public Property Source As String
        Public Property Field_Name As String
        Public Property Field_Type As String
        Public Property strSourceColumn As String
        Public Property strSourceName As String
    End Class
 
    Dim query = From tblSources In writingEntities.vw_Source_Columns.AsNoTracking
    query = query.Where(Function(tblSources) tblSources.strSourceName = tblName).OrderBy(Function(tblSources) tblSources.strSourceColumn)
    Dim lstfields As List(Of vw_UI_List_Source_Columns) = query.Cast(Of vw_UI_List_Search_Columns).ToList() 
