    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
			CreateDetailTable()
        End If
    End Sub
    ''' <summary>
    ''' create the detail table and store in a session var
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateDetailTable()
        Dim dt As New DataTable
        dt.Columns.Add("McsStatusId")
        dt.Columns.Add("McsHeaderId")
        dt.Columns.Add("SeqNo")
        dt.Columns.Add("Status")
        dt.Columns.Add("DateTime")
        dt.Columns.Add("Timezone")
        dt.Columns.Add("Location")
        dt.Columns.Add("State")
        dt.Columns.Add("Country")
        dt.Columns.Add("Comments")
        dt.Columns.Add("TransmittedFlag")
        dt.Columns.Add("TransmissionNo")
        dt.Columns.Add("AddUserId")
        dt.Columns.Add("AddTime")
        dt.Columns.Add("LastUserId")
        dt.Columns.Add("LastTime")
        dt.Columns.Add("DeleteFlag")
        Session(hdnSessionVar.Value) = dt
    End Sub
	
	
    ''' <summary>
    ''' add detail record to the table stored in the session, then use this table to refresh the grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Function AddDetailToGrid() As Boolean
        Dim rtn As Boolean = False
        Try
            Dim u As New ClassUserProfile
            u.GetUserFromSession()
            Dim dt As DataTable = TryCast(Session(hdnSessionVar.Value), DataTable)
            Dim dr As DataRow
            dr = dt.NewRow
            dr("McsStatusId") = 0 'filler
            dr("McsHeaderId") = hdnMcsHeaderId.Value 'filler
            dr("SeqNo") = 0 'filler
            dr("Status") = ddlStatus.SelectedItem.Text.Trim
            dr("DateTime") = txtStatusDate.Text.Trim & " " & txtStatusTime.Text.Trim
            dr("Timezone") = ddlTimezones.SelectedItem.Text.Trim
            dr("Location") = txtStatusLocation.Text.Trim
            dr("State") = txtStatusState.Text.Trim
            dr("Country") = txtStatusCountry.Text.Trim
            dr("Comments") = txtStatusComments.Text.Trim
            dr("TransmittedFlag") = 0 'these two fields should not be able to be added by user, they will be updated in a DB job that runs, and
            dr("TransmissionNo") = 0 'once they are set this status detail record will no longer be editable
            dr("AddUserId") = 0 'filler
            dr("AddTime") = DateTime.Now 'filler
            dr("LastUserId") = 0 'filler
            dr("LastTime") = DateTime.Now  'filler
            dr("DeleteFlag") = 0 'filler
            If hdnSeqNo.Value = "" Then
                dt.Rows.Add(dr)
            Else
                dt.Rows.InsertAt(dr, hdnSeqNo.Value)
            End If
            Session(hdnSessionVar.Value) = dt 'update the session var
            'bind the grid
            gridMcsStatus.DataSource = dt
            gridMcsStatus.DataBind()
            rtn = True
        Catch ex As Exception
            mbStatus.ShowErrorMsg("There was an error adding to the grid: " & ex.ToString)
        End Try
        Return rtn
    End Function
	
    ''' <summary>
    ''' bind the session var containing the table data to the grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BindStatusDetailGrid()
        Using dt As DataTable = TryCast(Session(hdnSessionVar.Value), DataTable)
            gridMcsStatus.DataSource = dt
            gridMcsStatus.DataBind()
        End Using
    End Sub
