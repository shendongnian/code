    Private Sub GetVideoCategories()
        Dim objYouTubeService As YouTubeService
        AddToLog("GetVideoCategories Begin", True, False)
        Try
            objYouTubeService = New YouTubeService(New BaseClientService.Initializer() With { _
                 .HttpClientInitializer = OAUth2Credential, _
                 .ApplicationName = Assembly.GetExecutingAssembly().GetName().Name})
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "GetVideoCategories - Initialize YouTubeService")
            End
        End Try
        Dim objCategories As VideoCategoryListResponse = Nothing
        Try
            Dim objRequest As VideoCategoriesResource.ListRequest = New VideoCategoriesResource.ListRequest(objYouTubeService, "id,snippet")
            objRequest.Hl = "en_US"
            objRequest.RegionCode = "US"
            objCategories = objRequest.Execute
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "GetVideoCategories - VideoCategories List Request")
            End
        End Try
        cmbCategory.DisplayMember = "Title"
        cmbCategory.ValueMember = "Id"
        For Each obj As VideoCategory In objCategories.Items
            cmbCategory.Items.Add(New CategoryClass(obj.Id, obj.Snippet.Title))
            If obj.Snippet.Title.Contains("News") Then
                intDefaultCategoryIndex = cmbCategory.Items.Count - 1
            End If
        Next
        cmbCategory.SelectedIndex = intDefaultCategoryIndex
        AddToLog("GetVideoCategories End", True, False)
    End Sub
    Friend Class CategoryClass
    Dim m_Id As String
    Dim m_Title As String
    Sub New(ByVal Id As String, ByVal Title As String)
        m_Id = Id
        m_Title = Title
    End Sub
    Property ID As String
        Get
            ID = m_Id
        End Get
        Set(value As String)
            m_Id = value
        End Set
    End Property
    Property Title As String
        Get
            Title = m_Title
        End Get
        Set(value As String)
            m_Title = value
        End Set
    End Property
    Overrides Function ToString() As String
        ToString = m_Id & "|" & m_Title
    End Function
    End Class
