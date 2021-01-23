    Function GetControls() As Access.Controls
      Dim comp As VBIDE.VBComponent
      Dim proj As VBIDE.VBProject
      Dim props As VBIDE.Properties
      Dim bCloseFormWhenDone As Boolean
      Dim formName As String
      
      Set proj = Application.VBE.ActiveVBProject
      Set comp = proj.VBComponents("Form_Form1")
      On Error Resume Next
      Set props = comp.Properties
      On Error GoTo 0
      
      If props Is Nothing Then
        bCloseFormWhenDone = True
        'The form is not open, so open it in design mode
        formName = Mid(comp.Name, 6)
        Application.DoCmd.OpenForm formName, acDesign
      End If
      
      'Get the controls collection
      Set GetControls = comp.Properties("Controls").Object
      
      'Close the form if it wasn't already open
      If bCloseFormWhenDone Then
        Application.DoCmd.Close acForm, formName
      End If
    
    End Function
